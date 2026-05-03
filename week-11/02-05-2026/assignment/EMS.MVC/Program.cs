using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// 🔥 HttpClient for API
builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri("http://ems-api:8080/");
});

var app = builder.Build();

// 🔥 Show real errors (important for debugging)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Middleware
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route → Employee
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();