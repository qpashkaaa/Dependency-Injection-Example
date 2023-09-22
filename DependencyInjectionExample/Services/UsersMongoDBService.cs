using DependencyInjectionExample.Models;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class UsersMongoDBService : IUsersService
    {
        public Task<IEnumerable<User>> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
