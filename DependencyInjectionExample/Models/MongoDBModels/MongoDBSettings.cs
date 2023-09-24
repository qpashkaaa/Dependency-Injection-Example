namespace DependencyInjectionExample.Models.MongoDBModels
{
    public class MongoDBSettings : ConnectionSettings
    {
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string LogCollectionName { get; set; } = null!;
    }
}
