using Microsoft.EntityFrameworkCore;
using EVManager.Application;
using EVManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVehiculoService, VehiculoService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();                         
}

app.UseHttpsRedirection();    
app.UseStaticFiles();        
app.UseRouting();            
app.UseAuthorization();      


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehiculos}/{action=Index}/{id?}");

app.Run(); 