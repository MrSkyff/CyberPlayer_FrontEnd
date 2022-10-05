using MVC_Admin.Areas.Game.Interfaces;
using MVC_Admin.Areas.Game.Repositories;
using MVC_Admin.Areas.News.Interfaces;
using MVC_Admin.Areas.News.Repositories;
using MVC_Admin.Interfacies;
using MVC_Admin.Repositories;
using MVC_Admin.Services.ProtoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IGame, GameRepository>();
builder.Services.AddTransient<INews, NewsRepository>();
builder.Services.AddTransient<IImage, ImageRepository>();
builder.Services.AddTransient<Mapper>();

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
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
