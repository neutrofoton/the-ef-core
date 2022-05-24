using System;
using Microsoft.EntityFrameworkCore;
using TheEFCore.Domain.Model;

namespace TheEFCore.Repository.EFContext.Mapping
{
    public static class StudentMapping
    {
        public static void MapStudent(this ModelBuilder modelBuilder)
        {
            //[One to Many] Student - Grade
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                //.OnDelete(DeleteBehavior.Cascade)
                ;

            //[One to One] Student - Address -> v1: Map from Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(ad => ad.Student)
                .HasForeignKey<Address>(ad => ad.StudentId)
                ;

            //[One to One] Student - StudentAddress -> v2: Map from StudentAddress
            //modelBuilder.Entity<Address>()
            //    .HasOne(ad => ad.Student)
            //    .WithOne(s => s.Address)
            //    .HasForeignKey<Address>(ad => ad.StudentId)
            //    ;

            //[Many to Many] Student - Course via StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
