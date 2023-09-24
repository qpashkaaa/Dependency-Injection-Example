using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace DependencyInjectionExample.Models
{
    /*
     * A general data model from which data models for a specific service will then be inherited (implementation of inheritance in OOP)
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
