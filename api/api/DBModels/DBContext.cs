using Microsoft.EntityFrameworkCore;

namespace api.DBModels
{
  public class ApiContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseInMemoryDatabase(databaseName: "DemoDB");
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Project> Projects { get; set; }
  }
}
