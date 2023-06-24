using Application.Interfaces;
using Application.Interfaces.IApi;
using Application.UseCase.Pasajeros;
using Application.UseCase.Viajes;
using Application.UseServices;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Infraestructure.UseServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<ViajeContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPasajeroService, PasajeroService>();
builder.Services.AddScoped<IPasajeroCommand, PasajeroCommand>();
builder.Services.AddScoped<IPasajeroQuery, PasajeroQuery>();

builder.Services.AddScoped<IViajeService, ViajeService>();
builder.Services.AddScoped<IViajeCommand, ViajeCommand>();
builder.Services.AddScoped<IViajeQuery, ViajeQuery>();

builder.Services.AddScoped<IDestinoApi, DestinoApi>();
builder.Services.AddScoped<IServicioApi, ServicioApi>();
builder.Services.AddScoped<ITransporteApi, TransporteApi>();

//CORS deshabilitar
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
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
