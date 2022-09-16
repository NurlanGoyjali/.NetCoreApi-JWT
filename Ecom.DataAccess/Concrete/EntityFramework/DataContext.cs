using Ecom.DataAccess.Concrete.EntityFramework;
using Ecom.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Concrete
{
   public class DataContext  : DbContext
  {      
     protected override void OnConfiguring(
       DbContextOptionsBuilder optionsBuilder)
     {
         base.OnConfiguring(
           optionsBuilder.UseSqlServer(
             new AppSettings()._connectionString
             ));
     }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
          .Property(b => b.AddTime)
          .HasDefaultValueSql("getdate()");
      modelBuilder.Entity<User>()
          .Property(b => b.Active)
          .HasDefaultValueSql("0");
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Buy> Buys { get; set; }
    public DbSet<Sell> Sells { get; set; }
  }
}
