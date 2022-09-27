using Avtobus.Controllers;
using DataAccess;
using DataAccess.Reposiotory;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Services.LinkShorter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseMySql(
        builder.Configuration.GetConnectionString("MariaDBConnection"),
        MySqlServerVersion.LatestSupportedServerVersion
    ));

builder.Services.AddScoped<IRepository<Url>, UrlRepository>();

builder.Services.AddScoped<IShortLink, ShortLink>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var serviceScope=app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<AppDbContext>();
    context?.Database.Migrate();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "shortUrl",
        pattern: "{shortUrl}",
        defaults:new {controller="Home",action="RedirectToOriginal"}
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();