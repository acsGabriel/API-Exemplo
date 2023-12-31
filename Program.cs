using API_Exemplo;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inje��o de Depend�ncia
builder.Services.AddScoped<IAlunoSuperiorService, AlunoSuperiorService>();
builder.Services.AddScoped<IAlunoFundamentalService, AlunoFundamentalService >();
builder.Services.AddScoped<IAlunoInfantilService, AlunoInfantilService>();

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
