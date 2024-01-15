using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Content
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId MongoDBId { get; set; }
    public int Id { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }
}
