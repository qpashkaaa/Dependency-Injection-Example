using DependencyInjectionExample.Models;

namespace DependencyInjectionExample.Services.Interfaces
{
    // The abstraction that all services depend on to work with the database.

    public interface IUsersService
    {
        public Task<IEnumerable<User>> GetUser();
    }
}
