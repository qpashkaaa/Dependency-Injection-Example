using DependencyInjectionExample.Models;
using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace DependencyInjectionExample.Services
{
    /*
     * Logging service (will be implemented in user withdrawal services in order to save information about a request made from a client).
     */
    public class LoggerMongoDBService : ILoggerService
    {
        private readonly IMongoCollection<LogInfo> _requestsLogs;

        public LoggerMongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _requestsLogs = database.GetCollection<LogInfo>(mongoDBSettings.Value.LogCollectionName);
        }

        public async void Log(string serviceName)
        {
            LogInfo log = new LogInfo()
            {
                Hostname = System.Environment.MachineName,
                RequestTime = DateTime.Now,
                RequestTimeLocal = DateTime.Now.ToString(),
                ServiceName = serviceName,
            };
            await _requestsLogs.InsertOneAsync(log);
        }
    }
}
