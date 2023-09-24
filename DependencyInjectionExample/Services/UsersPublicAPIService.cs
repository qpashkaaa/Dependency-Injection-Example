using DependencyInjectionExample.Models.PublicAPIModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.Extensions.Options;


namespace DependencyInjectionExample.Services
{
    /*
     * Сервис вывода американских пользователей(получение данных со стороннего API). Здесь можно наблюдать реализацию интерфейса IUserService, а так же внедрение сервиса в сервис
     * (Внедрение LoggerMongoDBService в UsersPublicAPIService в конструкторе).
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
