using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DependencyInjectionExample.Services
{
    /*
     * Russian user withdrawal service (from MongoDB). Here you can observe the implementation of the IUserService interface, as well as the implementation of the service into the service
     * (Embedding LoggerMongoDBService in UsersMongoDBService in the constructor).
     */
    public class UsersMongoDBService : IMongoDBUsersService
    {
        private readonly IMongoCollection<MongoDBUser> _users;

        public UsersMongoDBService(IOptions<MongoDBSettings> mongoDBSettings, ILoggerService logger)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _users = database.GetCollection<MongoDBUser>(mongoDBSettings.Value.CollectionName);
            logger.Log(typeof(UsersMongoDBService).Name);
        }

        public async Task<IEnumerable<MongoDBUser>> GetUsers()
        {
            return await _users.Find(new BsonDocument()).ToListAsync();
        }
    }
}
