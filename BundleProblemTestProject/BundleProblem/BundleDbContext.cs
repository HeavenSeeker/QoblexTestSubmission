using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleProblem
{
  public class BundleDbContext : DbContext
  {
    public BundleDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;database=bundledb;Integrated Security=True;Connect Timeout=2;Encrypt=False;Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Bundle>().HasMany(x => x.Parts).WithOne(x => x.Parent).OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Bundle> Bundles { get; set; }
  }
}
