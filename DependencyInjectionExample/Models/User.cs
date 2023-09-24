using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace DependencyInjectionExample.Models
{
    /*
     * A general data model from which data models for a specific service will then be inherited (implementation of inheritance in OOP)
     */
    public class User
    {
        [BsonElement("first_name")]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [BsonElement("last_name")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [BsonElement("username")]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [BsonElement("password")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [BsonElement("address")]
        [JsonPropertyName("address")]
        public UserAddress Address { get; set; }
    }
}
