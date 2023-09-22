using DependencyInjectionExample.Models;
using DependencyInjectionExample.Services.Interfaces;
using System.IO;

namespace DependencyInjectionExample.Services
{
    /*
     * A service that implements receiving users via a third-party API. 
     * Adhering to the principle of Dependency Injection, it should be easily replaceable and loosely coupled. 
     * It is replaced, in this example, by the UsersMongoDBService service, if necessary. 
     * We can simply change the service used without changing the code in this service.
     */
    public class UsersPublicAPIService : IUsersService
    {
        static HttpClient client = new HttpClient();
        private const string URL = "https://random-data-api.com/api/v2/users?size=10&response_type=json&fields=id";
        public async Task<IEnumerable<User>> GetUser()
        {
            List<User> users = new List<User>();

            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadFromJsonAsync<List<User>>();
            }

            return users;
        }
    }
}
