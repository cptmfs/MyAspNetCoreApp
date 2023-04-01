using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>  //DBContext ekle <AppDbContext> 'i ekle
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")); // SqlServer kullan , builder'�n configration dedi�imiz "appsettings.json" i�erisindeki configrationlar� okur. .GetConnectionString ile oradaki Connection String'i al dedik ? hangisini ? ("SqlCon") parantez i�erisinde connectionString'e verdi�imiz ismi belirttik..
});

builder.Services.AddScoped<IHelper, Helper>(); //Bir singleton ( bir kez �ret ) nesne ekleyeceksin,  herhangi bir class'�n constructor veya methodunda IHelper g�r�rsen , Helper s�n�f�ndan bir nesne �ret // Scope �evirdik..


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
