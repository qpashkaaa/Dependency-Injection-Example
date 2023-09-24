using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Models.PublicAPIModels;
using DependencyInjectionExample.Services;
using DependencyInjectionExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*
 * Добавляем конфигурации определенные в файле appsettings.json(ссылка для запроса и строки подключения к MongoDB)
 */
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.Configure<PublicAPISettings>(builder.Configuration.GetSection("PublicAPI"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*
 * Добавляем используемые сервисы. При чем, сначала добавляется сервис логгера, т.к. сервисы вывода пользователей используют его.
 */
builder.Services.AddScoped<ILoggerService, LoggerMongoDBService>();
builder.Services.AddTransient<IPublicAPIUsersService, UsersPublicAPIService>();
builder.Services.AddTransient<IMongoDBUsersService, UsersMongoDBService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
