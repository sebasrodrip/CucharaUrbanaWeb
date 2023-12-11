using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConnString

string connString = builder
                            .Configuration
                            .GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<CucharaUrbanaContext>(options =>
                        options.UseSqlServer(
                           connString
                            ));

Util.ConnectionString = connString;

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependecy Injection
builder.Services.AddDbContext<CucharaUrbanaContext>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IFacturaDAL, FacturaDALImpl>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IRolDAL, RolDALImpl>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<ICategoriumService, CategoriumService>();
builder.Services.AddScoped<ICategoriumDAL, CategoriumDALImpl>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoDAL, ProductoDALImpl>();
builder.Services.AddScoped<IPedidoDAL, PedidoDALImpl>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IReservacionDAL, ReservacionDALImpl>();
builder.Services.AddScoped<IReservacionService, ReservacionService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
