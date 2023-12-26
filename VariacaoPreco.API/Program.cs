using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Core.Interface;
using VariacaoPreco.Core.Service;
using VariacaoPreco.Data.Repository;
using VariacaoPreco.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddSingleton(configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("VariacaoAWS")));

// Adiciona AtivoService como um serviço de escopo
builder.Services.AddScoped<AtivoService>();
builder.Services.AddScoped<IAtivo, AtivoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
