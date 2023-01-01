var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// TODO: Take https port from config file
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
