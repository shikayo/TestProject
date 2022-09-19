using DataAccess;
using DataAccess.Reposiotory;
using Domain;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Services.UrlShorter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseMySql(
        builder.Configuration.GetConnectionString("MariaDBConnection"),
        MySqlServerVersion.LatestSupportedServerVersion
    ));

builder.Services.AddScoped<IRepository<Url>, UrlRepository>();

builder.Services.AddSingleton<IShortLink, ShortLink>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();