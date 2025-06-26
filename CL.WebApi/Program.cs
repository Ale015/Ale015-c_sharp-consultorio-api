// Cria o builder da WebApplication para adicionar as dependências e configurar o pipeline de requisições.
using CL.Data.Context;
using CL.Data.Repository;
using CL.Manager.Implementations;
using CL.Manager.Interfaces;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adição de serviços ao contêiner.
// Adição de Controller I Endpoints I Swagger
builder.Services.AddControllers();

builder.Services.AddDbContext<ClContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("db_consultorio")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteManager, ClienteManager>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Adição de serviços de injeção de dependência
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

// Rodar a aplicação
app.Run();