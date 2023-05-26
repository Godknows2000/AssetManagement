using AMS.Data;
using AMS.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using wCyber.Helpers.Identity.Auth;
using wCyber.Lib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("AssetManagementDbConn");
builder.Services.AddDbContext<AssetManagementContext>(options => options.UseNpgsql(connectionString));

builder.Services.Configure<UserRoleTypeOptions>(o =>
{
    o.RoleType = typeof(UserRole);
});

builder.Services.AddDefaultIdentity<AMS.Data.User>()
    .AddUserStore<SysUserStore<AMS.Data.User, AssetManagementContext>>()
    .AddClaimsPrincipalFactory<SysUserStore<AMS.Data.User, AssetManagementContext>>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(o =>
{
    o.ExpireTimeSpan = TimeSpan.FromDays(15);
    //o.LoginPath = new PathString("/Login");
    //o.AccessDeniedPath = new PathString("/AccessDenied");
    o.SlidingExpiration = true;
    o.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    {
        OnSigningIn = async context => await context.InitUser()
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserNameClaimType = ClaimTypes.Name;
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
    options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
