using Microsoft.AspNetCore.Authentication.Cookies;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Game.Repositories;
using MVC_FrontEnd.Areas.Group.Interfaces;
using MVC_FrontEnd.Areas.Group.Repositories;
using MVC_FrontEnd.Areas.Identity.Interfaces;
using MVC_FrontEnd.Areas.Identity.Repositories;
using MVC_FrontEnd.Areas.News.Interfaces;
using MVC_FrontEnd.Areas.News.Repositories;
using MVC_FrontEnd.Services.Mapper;

//===================================================================//
//                        SERVICE BUILDER                            //
//===================================================================//

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//{
//    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Home/Login");
//    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Home/Login");
//    options.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Home/Login");
//});
//builder.Services.AddAuthorization();


builder.Services.AddTransient<IGame, GameRepository>();
builder.Services.AddTransient<INews, NewsRepository>();
builder.Services.AddTransient<IGroup, GroupRepository>();
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<Mapper>();

//builder.Services.AddDataProtection();

//===================================================================//
//                        APPLICATIONS                               //
//===================================================================//

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

//app.UseAuthentication();
//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
