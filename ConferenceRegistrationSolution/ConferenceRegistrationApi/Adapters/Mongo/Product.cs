using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConferenceRegistrationApi.Adapters.Mongo;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    [BsonElement("name")]
    public string Name { get; set; } = "";

    [BsonElement("cost")]
    public decimal Cost { get; set; }
}
