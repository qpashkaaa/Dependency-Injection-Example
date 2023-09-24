using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace DependencyInjectionExample.Models
{
    /*
     * Общая модель данных, от которой потом будут наследоваться модели данных для конкретного сервиса(реализация наследования в ООП)
     */
    public class UserAddress
    {
        [BsonElement("city")]
        [JsonPropertyName("city")]
        public string City { get; set; }
        [BsonElement("street_name")]
        [JsonPropertyName("street_name")]
        public string StreetName { get; set; }
        [BsonElement("street_address")]
        [JsonPropertyName("street_address")]
        public string StreetAddress { get; set; }
        [BsonElement("state")]
        [JsonPropertyName("state")]
        public string State { get; set; }
        [BsonElement("country")]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
