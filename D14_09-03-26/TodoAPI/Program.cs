using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddControllers();

// Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Swagger API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();


// Middleware Pipeline

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS
app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowFrontend");

// Authorization
app.UseAuthorization();

// Map Controllers
app.MapControllers();

// Run Application
app.Run();