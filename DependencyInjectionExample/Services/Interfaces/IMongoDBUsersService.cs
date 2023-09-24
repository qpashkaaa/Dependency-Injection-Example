using DependencyInjectionExample.Models.MongoDBModels;

namespace DependencyInjectionExample.Services.Interfaces
{
    public interface IMongoDBUsersService : IUsersService<MongoDBUser>
    {

    }
}
