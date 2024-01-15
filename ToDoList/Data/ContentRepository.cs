using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

public class ContentRepository
{
    private readonly IMongoCollection<Content> _collection;

    public ContentRepository(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Content>("content");
    }

    private int GetNextId() => _collection.AsQueryable().Max(c => (int?)c.Id) + 1 ?? 1;

    public void CreateContent(Content content)
    {
        content.Id = GetNextId();
        _collection.InsertOne(content);
        Console.WriteLine("Conteúdo criado com sucesso!");
    }

    public List<Content> ReadContents() => _collection.AsQueryable().ToList();

    public void UpdateContent(int id, string newDescription)
    {
        var content = _collection.AsQueryable().FirstOrDefault(c => c.Id == id);
        if (content != null)
        {
            content.Description = newDescription;
            _collection.ReplaceOne(c => c.Id == id, content);
            Console.WriteLine("Conteúdo atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Conteúdo não encontrado.");
        }
    }

    public void DeleteContent(int id)
    {
        var result = _collection.DeleteOne(c => c.Id == id);
        Console.WriteLine(result.DeletedCount > 0 ? "Conteúdo excluído com sucesso!" : "Conteúdo não encontrado.");
    }
}
