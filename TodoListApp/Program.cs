using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoListApp.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToDosAppDatabase;Trusted_Connection=true;"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Scan(scan => scan.FromCallingAssembly().AddClasses(publicOnly: false)
    .AsImplementedInterfaces()
    .WithScopedLifetime());

// TODO: Take constants from config file
builder.WebHost.UseUrls("https://*:443");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
