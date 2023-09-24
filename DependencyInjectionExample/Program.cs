using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Models.PublicAPIModels;
using DependencyInjectionExample.Services;
using DependencyInjectionExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*
 * ��������� ������������ ������������ � ����� appsettings.json(������ ��� ������� � ������ ����������� � MongoDB)
 */
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.Configure<PublicAPISettings>(builder.Configuration.GetSection("PublicAPI"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*
 * ��������� ������������ �������. ��� ���, ������� ����������� ������ �������, �.�. ������� ������ ������������� ���������� ���.
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
