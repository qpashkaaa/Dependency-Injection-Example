using DependencyInjectionExample.Models;
using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace DependencyInjectionExample.Services
{
    /*
     * Сервис логирования(будет внедрятся в сервисы по выводу пользователей,чтобы сохранять информацию о сделанном запросе от какого-либо клиента).
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
