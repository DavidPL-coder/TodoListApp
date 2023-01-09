using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoListApp;
using TodoListApp.DAL;

var builder = WebApplication.CreateBuilder(args);

var appConfig = new AppConfig();
builder.Configuration.GetSection("AppConfig").Bind(appConfig);
builder.Services.AddSingleton(appConfig);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(appConfig.ConnectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Scan(scan => scan.FromCallingAssembly().AddClasses(publicOnly: false)
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.WebHost.UseUrls(appConfig.UrlsUsedForRunning);

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
