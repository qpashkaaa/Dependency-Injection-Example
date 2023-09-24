using System.Text.Json.Serialization;

namespace DependencyInjectionExample.Models.PublicAPIModels
{ 
    public class PublicAPIUser : User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("uid")]
        public Guid Uid { get; set; }
    }
}
