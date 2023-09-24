namespace DependencyInjectionExample.Models
{
    /*
     * A general data model from which data models for a specific service will then be inherited (implementation of inheritance in OOP)
     */
    public class ConnectionSettings
    {
        public string ConnectionURI { get; set; } = null!;
    }
}
