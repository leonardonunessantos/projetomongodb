using MongoDB.Driver;
using MongoDB.Bson;
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

    private int GetNextId()
    {
        var maxId = _collection.AsQueryable().Any() ? _collection.AsQueryable().Max(c => c.Id) : 0;
        return maxId + 1;
    }

    public void CreateContent(Content content)
    {
        content.Id = GetNextId();
        _collection.InsertOne(content);
        Console.WriteLine("Conteúdo criado com sucesso!");
    }

    public List<Content> ReadContents()
    {
        return _collection.Find(new BsonDocument()).ToList();
    }

    public void UpdateContent(int id, string newDescription)
    {
        var filter = Builders<Content>.Filter.Eq(c => c.Id, id);
        var update = Builders<Content>.Update.Set(c => c.Description, newDescription);
        _collection.UpdateOne(filter, update);
        Console.WriteLine("Conteúdo atualizado com sucesso!");
    }

    public void DeleteContent(int id)
    {
        var filter = Builders<Content>.Filter.Eq(c => c.Id, id);
        _collection.DeleteOne(filter);
        Console.WriteLine("Conteúdo excluído com sucesso!");
    }
}
