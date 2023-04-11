 using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>  //DBContext ekle <AppDbContext> 'i ekle
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")); // SqlServer kullan , builder'ýn configration dediðimiz "appsettings.json" içerisindeki configrationlarý okur. .GetConnectionString ile oradaki Connection String'i al dedik ? hangisini ? ("SqlCon") parantez içerisinde connectionString'e verdiðimiz ismi belirttik..
});

builder.Services.AddScoped<IHelper, Helper>(); //Bir singleton ( bir kez üret ) nesne ekleyeceksin,  herhangi bir class'ýn constructor veya methodunda IHelper görürsen , Helper sýnýfýndan bir nesne üret // Scope Çevirdik..

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Çalýþmýþ oldugum assembly'i ver.

builder.Services.AddScoped<NotFoundFilter>(); //Scope request response dönüsünceye kadar ayný örnegi verir. Filterlardak istek gelince calýstýgý için scope uygun oldu.

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

//blog/abc => blog controller > article action method çalýþsýn
//blog/fds => blog controller > article action method çalýþsýn
//app.MapControllerRoute(
//    name: "productpages",
//    pattern: "blog/{*article}",
//    defaults:new { controller="Blog",action="Article"});

//app.MapControllerRoute(
//    name: "article",
//    pattern: "{controller=Blog}/{action=Article}/{name}/{id}");

//app.MapControllerRoute(
//    name: "productpages",
//    pattern: "{controller}/{action}/{page}/{pagesize}");

//app.MapControllerRoute(
//    name: "getbyid",
//    pattern: "{controller}/{action}/{productid}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllers(); 

app.Run();
