using ACBarberShop.Application.Profiles;
using ACBarberShop.Application.Services.Implemetations;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Infraestructure.Repository.Implemetations;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using System.Text;
using ACBarberShop.Web.Middleware;
using ACBarberShop.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//=================================Repository==================================
builder.Services.AddTransient<IRepositoryProducto, RepositoryProducto>();
builder.Services.AddTransient<IRepositoryFactura, RepositoryFactura>();
builder.Services.AddTransient<IRepositoryCita, RepositoryCita>();
builder.Services.AddTransient<IRepositoryCategoria, RepositoryCategoria>();
builder.Services.AddTransient<IRepositoryServicio, RepositoryServicio>();
builder.Services.AddTransient<IRepositorySucursal, RepositorySucursal>();
builder.Services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();


//=================================Services==================================
builder.Services.AddTransient<IServiceProducto, ServiceProducto>();
builder.Services.AddTransient<IServiceFactura, ServiceFactura>();
builder.Services.AddTransient<IServiceCita, ServiceCita>();
builder.Services.AddTransient<IServiceCategoria, ServiceCategoria>();
builder.Services.AddTransient<IServiceServicio, ServiceServicio>();
builder.Services.AddTransient<IServiceSucursal, ServiceSucursal>();
builder.Services.AddTransient<IServiceUsuario, ServiceUsuario>();


//=================================Automapper==================================
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<CategoriaProfile>();
    config.AddProfile<CitaProfile>();
    config.AddProfile<DireccionProfile>();
    config.AddProfile<EstadoBloqueoProfile>();
    config.AddProfile<EstadoCitaProfile>();
    config.AddProfile<EstadoFacturaProfile>();
    config.AddProfile<FacturaProfile>();
    config.AddProfile<FacturaServicioProfile>();
    config.AddProfile<HorarioProfile>();
    config.AddProfile<ProductoProfile>();
    config.AddProfile<RolProfile>();
    config.AddProfile<ServicioProfile>();
    config.AddProfile<RolProfile>();
    config.AddProfile<SucursalProfile>();
    config.AddProfile<UsuarioProfile>();

});




// Configuar Conexión a la Base de Datos SQL
builder.Services.AddDbContext<BarberShopContext>(options =>
{
    // it read appsettings.json file
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDataBase"));

    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});


//========================================
//Configuración Serilog
// Logger. P.E. Verbose = muestra SQl Statement
var logger = new LoggerConfiguration()
     // Limitar la información de depuración
     .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.FromLogContext()
    // Log LogEventLevel.Verbose muestra mucha información, pero no es necesaria solo para el proceso de depuración
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File(@"Logs\Info-.log", shared: true, encoding:
    Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.File(@"Logs\Debug-.log", shared: true, encoding:
    System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
    LogEventLevel.Warning).WriteTo.File(@"Logs\Warning-.log", shared: true, encoding:
    System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
     .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
    LogEventLevel.Error).WriteTo.File(@"Logs\Error-.log", shared: true, encoding:
    Encoding.ASCII, rollingInterval: RollingInterval.Day))
     .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
    LogEventLevel.Fatal).WriteTo.File(@"Logs\Fatal-.log", shared: true, encoding:
    Encoding.ASCII, rollingInterval: RollingInterval.Day))
     .CreateLogger();
builder.Host.UseSerilog(logger);

//========================================



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    // Error control Middleware

    app.UseMiddleware<ErrorHandlingMiddleware>();
}



//Activar soporte a la solicitud de registro con SERILOG
app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Activar Antiforgery 
app.UseAntiforgery();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();