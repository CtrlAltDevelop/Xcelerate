using Microsoft.EntityFrameworkCore;
using Xcelerate.Models;
namespace Xcelerate.Data;


public class XDbContext : DbContext
{
    public XDbContext(DbContextOptions<XDbContext> options) : base(options) { }

    // DbSet
    public DbSet<ExcelData> YourEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
