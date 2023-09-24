namespace DependencyInjectionExample.Models
{
    /*
     * Общая модель данных, от которой потом будут наследоваться модели данных для конкретного сервиса(реализация наследования в ООП)
     */
    public class ConnectionSettings
    {
        public string ConnectionURI { get; set; } = null!;
    }
}
