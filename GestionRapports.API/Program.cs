using GestionRapports.BLL.Interfaces;
using GestionRapports.BLL.Services;
using GestionsRapports.DAL.Interfaces;
using GestionsRapports.DAL.Repositories.ADO_Repository;
using Microsoft.Data.SqlClient;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Récupérer la chaîne de connexion depuis appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Enregistrer IUserRepository avec la chaîne de connexion
builder.Services.AddScoped<IUserRepository>(provider => new UserRepository(connectionString));

// Enregistrer IUserService
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();