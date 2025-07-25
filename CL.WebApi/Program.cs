// Cria o builder da WebApplication para adicionar as depend�ncias e configurar o pipeline de requisi��es.
using CL.Data.Context;
using CL.Data.Repository;
using CL.Manager.Implementations;
using CL.Manager.Interfaces;
using CL.Manager.Validator;
using FluentAssertions.Common;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Adi��o de servi�os ao cont�iner.
// Adi��o de Controller I Endpoints I Swagger
builder.Services.AddControllers().AddFluentValidation(p =>
    {
        p.RegisterValidatorsFromAssemblyContaining<ClienteValidator>();
        p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
    }
);

builder.Services.AddDbContext<ClContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("db_consultorio")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteManager, ClienteManager>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Adi��o de servi�os de inje��o de depend�ncia
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

// Rodar a aplica��o
app.Run();