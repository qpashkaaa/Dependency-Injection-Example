using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Models.PublicAPIModels;
using DependencyInjectionExample.Services;
using DependencyInjectionExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*
 * Adding the configurations defined in the appsettings.json file (link for request and connection string to MongoDB)
 */
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.Configure<PublicAPISettings>(builder.Configuration.GetSection("PublicAPI"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*
 * Adding the services used. At the same time, the logger service is added first, because user output services use it.
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
