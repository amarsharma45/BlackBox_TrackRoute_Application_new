using BlackBox_TrackRoute_Application.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Infrastructure.Entities;
using TrackRoute_Application.Infrastructure.Repository;
using TrackRoute_Application.Services.Implementation;
using TrackRoute_Application.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrackRoute_ApplicationConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/ManageUser/Login";
        options.LogoutPath = "/ManageUser/Logout";
    });

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IManageLoad, ManageLoad>();
builder.Services.AddScoped<IManageTruck, ManageTruck>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IManageLoadService, ManageLoadService>();
builder.Services.AddScoped<ITruckService, TruckService>();


// Add MVC and Razor Pages
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // detailed error page for dev
}
else
{
    app.UseExceptionHandler("/Error"); // production error handler
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication here if needed
app.UseAuthentication();
app.UseAuthorization();

// Map controller routes first to avoid conflict with Razor Pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ManageUser}/{action=Index}/{id?}"
);

// Map Razor Pages after controllers
//app.MapRazorPages();

app.Run();
