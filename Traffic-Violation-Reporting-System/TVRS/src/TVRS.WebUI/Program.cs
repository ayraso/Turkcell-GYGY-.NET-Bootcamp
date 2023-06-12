using TVRS.Application.Mappings;
using TVRS.Infrastructure.Data_Context;
using TVRS.WebUI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Oturum y�netimini etkinle�tirme
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum s�resi
});

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddInjections(connectionString);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Authentication ve Cookie ayarlar�
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Oturum s�resi
        options.LoginPath = "/User/Index"; // Giri� sayfas�n�n yolu
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<TvrsDbContext>();
context.Database.EnsureCreated();
TVRS.Infrastructure.Data_Seeder.TvrsDbSeeder.Seed(context);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); // Oturum y�netimini kullanma

app.UseRouting();

app.UseAuthentication(); // Authentication kullan�m� eklendi

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
