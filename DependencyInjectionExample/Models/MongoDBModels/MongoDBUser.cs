using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DependencyInjectionExample.Models.MongoDBModels
{
    public class MongoDBUser : User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
