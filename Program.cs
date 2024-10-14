using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.SqlServer;
using Xcelerate.Data;

var builder = WebApplication.CreateBuilder(args);

// Set up the MSSQL connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

// Configure Entity Framework Core to use SQL Server
builder.Services.AddDbContext<XDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Configure Hangfire to use SQL Server
builder.Services.AddHangfire(config =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
          {
              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
              QueuePollInterval = TimeSpan.Zero,
              UseRecommendedIsolationLevel = true,
              DisableGlobalLocks = true
          });
});

// Add the Hangfire server for background processing
builder.Services.AddHangfireServer();

// Add other services to the container
builder.Services.AddControllers();
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

// Global error handling
app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { error = "An error occurred while processing your request." });
    }
});

// Swagger setup
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS if configured
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

// Map Hangfire dashboard
app.UseHangfireDashboard();

app.MapControllers();

app.Run();
