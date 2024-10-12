using Microsoft.EntityFrameworkCore;
using Xcelerate.Data;

var builder = WebApplication.CreateBuilder(args);


// Determine which connection string to use based on the environment
string connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("SQLiteConnection")! // Use SQLite for development
    : builder.Configuration.GetConnectionString("MSSQLConnection")!; // Use MSSQL for production

builder.Services.AddDbContext<XDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlite(connectionString); // Use SQLite in development
    }
    else
    {
        options.UseSqlServer(connectionString); // Use SQL Server in production
    }
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS if configured
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
