using Microsoft.EntityFrameworkCore;
using MonopolyTestTask.Data;
using MonopolyTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTests
{
    internal class ApplicationContext : DbContext, IDbContext
    {
        public DbSet<Pallete> Palletes { get; set; }
        public DbSet<Box> Boxes { get; set; }  
        public ApplicationContext()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Box>().ComplexProperty(e => e.Size, size =>
            {
                size.Property(s => s.Height).HasColumnName("Height");
                size.Property(s => s.Width).HasColumnName("Width");
                size.Property(s => s.Depth).HasColumnName("Depth");
            });
            modelBuilder.Entity<Pallete>().ComplexProperty(e => e.Size, size =>
            {
                size.Property(s => s.Height).HasColumnName("Height");
                size.Property(s => s.Width).HasColumnName("Width");
                size.Property(s => s.Depth).HasColumnName("Depth");
            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Storagedb");
        }
    }
}
