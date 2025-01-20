using ProjectManagement.Infrastructure.Repositories;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IProjectRepository>(provider => new ProjectRepository(connectionString));

builder.Services.AddScoped<ProjectService>();

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(options => 
{ 
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Project Management API", 
        Version = "v1", 
        Description = "API para gerenciar projetos" 
        }); 
    }); 
        
var app = builder.Build();

// Configuração do Swagger UI no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Management API v1");
        options.RoutePrefix = string.Empty; // Acessar diretamente na raiz
    });
}


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5072); // Porta HTTP
    options.ListenAnyIP(7022, listenOptions =>
    {
        listenOptions.UseHttps(); // Porta HTTPS
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
