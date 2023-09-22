using DependencyInjectionExample.Services;
using DependencyInjectionExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
 * Registration of dependencies. If you build the logic and data models correctly, then when changing, for example, the resource where the data comes from, you can simply replace 
 * UsersPublicAPIService with UsersMongoDBService 
 * or UsersMongoDBService on UsersPublicAPIService
 */
builder.Services.AddTransient<IUsersService, UsersPublicAPIService>();

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
