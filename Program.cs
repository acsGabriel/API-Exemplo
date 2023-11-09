using API_Exemplo;
using API_Exemplo.Interfaces.Bancos;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;
using API_Exemplo.Validacoes;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inje��o de Depend�ncia - Servi�os
builder.Services.AddScoped<IAlunoSuperiorService<AlunoSuperior> , AlunoSuperiorService <AlunoSuperior> >();
builder.Services.AddScoped<IAlunoFundamentalService<AlunoFundamental>, AlunoFundamentalService<AlunoFundamental> >();
builder.Services.AddScoped<IAlunoInfantilService<AlunoInfantil>, AlunoInfantilService<AlunoInfantil> >();

//Inje��o de Depend�ncia - Banco De Dados
builder.Services.AddScoped<IBancoDeDados, BancoDeDados>();

//Inje��o de Depend�ncia - Valida��es
builder.Services.AddScoped<IValidator<AlunoInfantil>, AlunoInfantilValidacao>();
builder.Services.AddScoped<IValidator<AlunoFundamental>, AlunoFundamentalValidacao>();
builder.Services.AddScoped<IValidator<AlunoSuperior>, AlunoSuperiorValidacao>();

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
