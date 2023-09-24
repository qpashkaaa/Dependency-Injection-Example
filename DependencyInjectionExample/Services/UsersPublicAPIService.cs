using DependencyInjectionExample.Models.PublicAPIModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.Extensions.Options;


namespace DependencyInjectionExample.Services
{
    /*
     * A service for the withdrawal of American users (receiving data from a third-party API). Here you can observe the implementation of the IUserService interface, as well as the implementation of the service into the service
     * (Implementation of LoggerMongoDBService in UsersPublicAPIService in the constructor).
     */
    public class UsersPublicAPIService : IPublicAPIUsersService
    {
        static HttpClient client;
        private string URL;

        public UsersPublicAPIService(IOptions<PublicAPISettings> publicAPISettings, ILoggerService logger)
        {
            client = new HttpClient();
            URL = publicAPISettings.Value.ConnectionURI;
            logger.Log(typeof(UsersPublicAPIService).Name);
        }
        public async Task<IEnumerable<PublicAPIUser>> GetUsers()
        {
            List<PublicAPIUser> users = new List<PublicAPIUser>();

            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadFromJsonAsync<List<PublicAPIUser>>();
            }

            return users;
        }
    }
}
