using API_Exemplo;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeção de Dependência
builder.Services.AddScoped<IAlunoSuperiorService<AlunoSuperior> , AlunoSuperiorService <AlunoSuperior> >();
builder.Services.AddScoped<IAlunoFundamentalService<AlunoFundamental>, AlunoFundamentalService<AlunoFundamental> >();
builder.Services.AddScoped<IAlunoInfantilService<AlunoInfantil>, AlunoInfantilService<AlunoInfantil> >();

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
