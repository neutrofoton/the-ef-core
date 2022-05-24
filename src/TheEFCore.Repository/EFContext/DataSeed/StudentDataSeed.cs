using System;
using Microsoft.EntityFrameworkCore;
using TheEFCore.Domain.Model;

namespace TheEFCore.Repository.EFContext.DataSeed
{
    public static class StudentDataSeed
    {
        public static void SeedStudent(this ModelBuilder modelBuilder)
        {
            Address address = new Address()
            {
                Id = 101,
                City = "jakarta",
                Country = "indonesia",
                ShortAddress = "jln. merdeka raya",
                State = "indonesia",
                StudentId=10
            };

            modelBuilder.Entity<Address>()
                .HasData(address);

            modelBuilder.Entity<Student>()
                .HasData(new Student()
                {
                    Id=10,
                    Address= address,
                    Grade = new Grade()
                    {
                        Name="Tingkat 1"
                    },
                    Name="fulan"
                });
        }
    }
}
