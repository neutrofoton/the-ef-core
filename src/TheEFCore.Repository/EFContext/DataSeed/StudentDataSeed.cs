using System;
using Microsoft.EntityFrameworkCore;
using TheEFCore.Domain.Model;

namespace TheEFCore.Repository.EFContext.DataSeed
{
    public static class StudentDataSeed
    {
        public static void SeedStudent(this ModelBuilder modelBuilder)
        {
            Passport address = new Passport()
            {
                Id = 101,
                No = "ID-1001",
                Nationality = "indonesian"
            };

            modelBuilder.Entity<Passport>()
                .HasData(address);

            modelBuilder.Entity<Student>()
                .HasData(new Student()
                {
                    Id=10,
                    Passport= address,
                    Grade = new Grade()
                    {
                        Name="Tingkat 1"
                    },
                    Name="fulan"
                });
        }
    }
}
