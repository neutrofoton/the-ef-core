using System;
using Microsoft.EntityFrameworkCore;
using TheEFCore.Domain.Model;
using TheEFCore.Repository.EFContext.Mapping;
using TheEFCore.Repository.EFContext.DataSeed;

namespace TheEFCore.Repository.EFContext
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapStudent();
            //modelBuilder.SeedStudent();
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> StudentAddresses { get; set; }
    }
}
