# Что это?
  **Пример использования Дженериков и реализации Dependency Injection (внедрения зависимостей) в ASP.NET Web API.**
  >*Это приложение было создано для демонстрации навыков реализации внедрения зависимостей в языке программирования C#. Оно состоит из 2-ух контроллеров, к которым мы можем обращаться для получения информации, и 3-ех сервисов: 1) Сервис логирования - занесение информации в MongoDB о запросе на сервисы. 2) Сервис получения русских пользователей - получение данных из БД MongoDB. 3) Сервис получения американских пользователей - получение данных со стороннего API. Предполагается, что с помощью использования Dependency Injection (внедрения зависимостей) можно легко заменить один сервис другим или же добавить новый.*

## Сервис получения русских пользователей (MongoDB)
### Скриншоты
_____
![1](https://github.com/qpashkaaa/Dependency-Injection-Example/assets/95401099/4c7f14d2-c718-4ac0-ae1e-7c84cd50e336)
_____
![2](https://github.com/qpashkaaa/Dependency-Injection-Example/assets/95401099/d21396a1-e839-43e0-a67d-f67a718c8184)
_____
![3](https://github.com/qpashkaaa/Dependency-Injection-Example/assets/95401099/5749c228-f2b0-4093-8ffe-7807bde04f4f)

## Сервис получения американских пользователей (Third-party API)
### Скриншоты
_____
![4](https://github.com/qpashkaaa/Dependency-Injection-Example/assets/95401099/a5604897-e506-405d-a291-37955c0a2eef)

## Сервис логирования запросов
### Скриншоты
_____
![5](https://github.com/qpashkaaa/Dependency-Injection-Example/assets/95401099/ec879670-01ad-4bb2-858d-5411b5c36204)

## Особенности
- **Реализация сервисов через несколько уровней абстракций с использованием Дженериков**
```C#
public interface IUsersService<T>
{
    public Task<IEnumerable<T>> GetUsers();
}
```
```C#
public interface IMongoDBUsersService : IUsersService<MongoDBUser>
{

}
```
- **Гибкое построение модели данных, путем использования принципа наследования в ООП**
```C#
public class User
{
    [BsonElement("first_name")]
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [BsonElement("last_name")]
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [BsonElement("username")]
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [BsonElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [BsonElement("password")]
    [JsonPropertyName("password")]
    public string Password { get; set; }

    [BsonElement("address")]
    [JsonPropertyName("address")]
    public UserAddress Address { get; set; }
}
```
```C#
public class MongoDBUser : User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
```
- **Реализация сервисов, с использованием возможностей фреймворка ASP.NET**
```C#
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
```
- **Использование асинхронного программирования для получения данных**
```C#
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
```
- **Реализация Dependency Injection(внедрения зависимостей)**
```C#
builder.Services.AddScoped<ILoggerService, LoggerMongoDBService>();
builder.Services.AddTransient<IPublicAPIUsersService, UsersPublicAPIService>();
builder.Services.AddTransient<IMongoDBUsersService, UsersMongoDBService>();
```
```C#
public MongoDBController(IMongoDBUsersService userService)
{
    _userSerice = userService;
    users = _userSerice.GetUsers().Result.ToList();
}
```
- **Логирование, с помощью специального сервиса, обращений ко всем сервисам по получению пользователей**
```C#
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
```


## Технологический стек
- **С#**
- **ASP.NET**
- **MongoDB**
- **Postman (Testing)**

## Зависимости
- **NuGet Packages**
  - ```MongoDB.Driver```

## Автор
- [Pavel Roslyakov](https://github.com/qpashkaaa)

## Контакты
- [Portfolio Website](https://portfolio-website-qpashkaaa.vercel.app/)
- [Telegram](https://t.me/qpashkaaa)
- [VK](https://vk.com/qpashkaaa)
- [LinkedIN](https://www.linkedin.com/in/pavel-roslyakov-7b303928b/)
