using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

//Add controllers
builder.Services.AddControllers();


//add database context service
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer (builder.Configuration.GetConnectionString("DefaultConnection")));


//add services to the containre
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// CORS (for HTML + JavaScript frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
