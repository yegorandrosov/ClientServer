using Androsov.Services.API;
using Androsov.Services.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAPI(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var username = config.GetValue<string>("API:Username");
    var password = config.GetValue<string>("API:Password");

    if (username == null || password == null)
    {
        throw new Exception("API not initialized");
    }

    return new BasicApiClientAuthentication(username, password);
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
#pragma warning restore ASP0014


app.Run();
