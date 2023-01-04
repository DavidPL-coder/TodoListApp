using Microsoft.EntityFrameworkCore;
using TodoListApp.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToDosAppDatabase;Trusted_Connection=true;"));

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
