using Microsoft.CodeAnalysis.CSharp.Syntax;
using NToastNotify;
using System.Diagnostics;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Business.Services.BusTripManagers;
using ZaferTurizm.Business.Services.CityManagers;
using ZaferTurizm.Business.Services.PassengerManagers;
using ZaferTurizm.Business.Services.RouteManagers;
using ZaferTurizm.Business.Services.TicketManagers;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.Business.Validators.Generics;
using ZaferTurizm.DataAccess;

var builder = WebApplication.CreateBuilder(args);

Trace.Listeners.Add(new TextWriterTraceListener("error-logs.txt"));
Trace.AutoFlush = true;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions() {CloseButton = true,PositionClass=ToastPositions.TopCenter});
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddTransient<IVehicleModelService, VehicleModelService>();
builder.Services.AddTransient<IVehicleDefinitionService,VehicleDefinitionService>();
builder.Services.AddTransient<IVehicleService,VehicleService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IPassengerService, PassengerService>(); 
builder.Services.AddTransient<IBusTripService, BusTripService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<BusTripValidator>();
builder.Services.AddTransient<RouteValidator>();
builder.Services.AddTransient<VehicleModelValidator>();
builder.Services.AddTransient<VehicleMakeValidator>();
builder.Services.AddTransient<VehicleDefinitionValidator>();
builder.Services.AddTransient<VehicleValidator>();
builder.Services.AddTransient(typeof(GenericValidator<>));
builder.Services.AddDbContext<TourDbContext>();



    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseNToastNotify();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
