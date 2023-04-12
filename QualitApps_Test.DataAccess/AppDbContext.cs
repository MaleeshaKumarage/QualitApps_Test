using Microsoft.EntityFrameworkCore;
using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                 .Property(x => x.Weight)
        .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Booking>()
                 .Property(x => x.Price)
        .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Invoice>()
                 .Property(x => x.Amount)
        .HasColumnType("decimal(18,4)");


        }
    }

}
