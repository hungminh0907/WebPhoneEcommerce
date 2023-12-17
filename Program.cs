using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using WebPhoneEcommerce.Areas.Admin.Models.TaiKhoan;
using WebPhoneEcommerce.Models.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//Code add testing push git (Phuong: 04/11/23)
