using MiddlewareExample.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

#region Map ve Run Kullanýmý
//app.use(async (context, next) =>
//{
//    await context.response.writeasync("before 1. middleware\n");
//    await next();
//    await context.response.writeasync("after 1. middleware\n");

//});

//app.use(async (context, next) =>
//{
//    await context.response.writeasync("before 2. middleware\n");
//    await next();
//    await context.response.writeasync("after 2. middleware\n");

//});

//app.run(async (context) =>
//{
//    await context.response.writeasync("terminal 3. middleware\n");
//});

#endregion

#region Map Kullanýmý
//app.Map("/ornek",app =>
//{
//    app.Run(async context =>
//    {
//        context.Response.WriteAsync("Ornek url için middleware");
//    });
//}); 
#endregion

#region MapWhen Kullanýmý
//app.MapWhen(context=>context.Request.Query.ContainsKey("name"),app=>
//{
//    app.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync("before 1. middleware\n");
//        await next();
//        await context.Response.WriteAsync("after 1. middleware\n");

//    });

//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("terminal 3. middleware\n");
//    });
//}); 
#endregion

app.UseMiddleware<WhiteIpAddressControlMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
