using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.IServices;
using Application.UseCase;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IPasajeroServices, PasajeroServices>();
builder.Services.AddScoped<IPasajeroCommand, PasajeroCommand>();
builder.Services.AddScoped<IPasajeroQuery, PasajeroQuery>();
builder.Services.AddScoped<IViajeServices, ViajeServices>();
builder.Services.AddScoped<IViajeCommand, ViajeCommand>();
builder.Services.AddScoped<IViajeQuery, ViajeQuery>();
builder.Services.AddScoped<IPasajeroViajeServices, PasajeroViajeServices>();
builder.Services.AddScoped<IPasajeroViajeCommand, PasajeroViajeCommand>();
builder.Services.AddScoped<IPasajeroViajeQuery, PasajeroViajeQuery>();


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
