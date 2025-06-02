using System;
using System.IO;
using System.Reflection;
using GlobalSolution.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var oracleConnectionString = builder.Configuration.GetConnectionString("OracleConnection");
if (string.IsNullOrEmpty(oracleConnectionString))
    throw new InvalidOperationException("ConnectionString 'OracleConnection' não encontrada.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(oracleConnectionString));

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Global Solution API",
        Version = "v1",
        Description = "API REST para gerenciamento de Usuários, Localizações e Lembretes",
        Contact = new OpenApiContact
        {
            Name = "Heitor Ortega Silva",
            Email = "heitor.ortega16@gmail.com"
        }
    });

    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    if (File.Exists(xmlFilePath))
    {
        c.IncludeXmlComments(xmlFilePath);
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Global Solution API v1");
        c.RoutePrefix = "swagger"; 
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
