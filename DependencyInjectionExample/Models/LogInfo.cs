using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DependencyInjectionExample.Models
{
    /*
     * Модель данных, для сервиса логирования
     */
    public class LogInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("serviceName")]
        public string ServiceName { get; set; }
        [BsonElement("hostname")]
        public string Hostname { get; set; }
        [BsonElement("requestTime")]
        public DateTime RequestTime { get; set; }
        [BsonElement("requestTimeLocal")]
        public string RequestTimeLocal { get; set; }
    }
}
