using Equipment_accounting.Controllers;
using Equipment_accounting.DataBase;
using Equipment_accounting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EquipmentBDContext>(options =>
{
 options.UseNpgsql(connection);
});

builder.Services.AddControllersWithViews()
.AddJsonOptions(options =>
{
 options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
 options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// Configure Identity Servieces
builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
     // Configure password policy.
     options.Password.RequiredLength = 4;
     options.Password.RequireDigit = false;
     options.Password.RequireLowercase = false;
     options.Password.RequireUppercase = false;
     options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EquipmentBDContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
 app.UseExceptionHandler("/Review/Error");
 app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Review}/{action=Index}/{id?}");

app.Run();
