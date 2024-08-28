using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi_Video.Context;
using WebApi_Video.Services.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Reconhece todas as inje��es de depend�ncia utilizando o IFuncionarioInterface. 
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();


// Realiza a liga��o por completo de tudo que foi instanciado com o banco de dados SQL SERVER 
// Essencial para qualquer aplica��o ASP.NET CORE 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});




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
