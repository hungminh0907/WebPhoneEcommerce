using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using WebPhoneEcommerce.Areas.Admin.Models.TaiKhoan;
using WebPhoneEcommerce.Models.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o =>
    o.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build()));


builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PhoneEcommerceContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("connectString"));
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient("Client").AddHttpMessageHandler<AuthHandled>();
builder.Services.AddTransient<AuthHandled>();

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;    
})
    .AddCookie(o =>
    {
        o.LoginPath = "/dang-nhap";
        o.AccessDeniedPath = "/access-denied";
        o.LogoutPath = "/logout";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


