using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BerberKuafor.Data;
using BerberKuafor.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BerberKuaforDBContextConnection") ?? throw new InvalidOperationException("Connection string 'BerberKuaforDBContextConnection' not found.");;

builder.Services.AddDbContext<BerberKuaforDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BerberKuaforUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BerberKuaforDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
    pattern: "{controller=AnaSayfa}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
