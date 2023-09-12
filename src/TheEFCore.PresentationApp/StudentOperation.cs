using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEFCore.Domain.Model;
using TheEFCore.Repository.EFContext;

namespace TheEFCore.PresentationApp
{
    public class StudentOperation
    {
        const string nameOfGradeA = "Grade A";
        const string nameOfStudentA = "Student A";
        const string nameOfCouse1 = "Course 1";
        const string nameOfCouse2 = "Course 2";

        public static void CreateGrade(DbContext context)
        {
            var exitingGradeA = context.Set<Grade>().FirstOrDefault<Grade>(g => g.Name == nameOfGradeA);
            if (exitingGradeA != null)
                return;

            var grade = new Grade()
            {
                Name = nameOfGradeA
            };

            //context.Grades.Add(std);
            context.Add<Grade>(grade);
            
            context.SaveChanges();
        }
        public static void CreateStudentAndPassport(DbContext context)
        {
            var grade = context.Set<Grade>().FirstOrDefault<Grade>(g => g.Name == nameOfGradeA);
            var studentA = context.Set<Student>().FirstOrDefault(s => s.Name == nameOfStudentA);
            if (studentA != null)
                return;

            var std = new Student()
            {
                Grade=grade,
                GradeId=grade.Id,
                Name = nameOfStudentA
            };
            context.Add<Student>(std);

            var pass = new Passport()
            {
                Nationality = "ID-Indonesian",
                No = "ID-1001",
                Student = std,
                StudentId = std.Id
            };

            std.Passport= pass;
            context.SaveChanges();

        }
        
        public static void CreateCoursesAndApplyToStudent(DbContext context)
        {
            var studentA = context.Set<Student>().FirstOrDefault(s => s.Name == nameOfStudentA);
            if (studentA == null)
                return;

            bool isNeedPersistToDB = false;

            //course-1
            Course course_1= context.Set<Course>().FirstOrDefault(c => c.Name == nameOfCouse1);
            isNeedPersistToDB |= course_1 == null;

            if (course_1 == null)
            {
                course_1 = new Course()
                {
                    Name = nameOfCouse1,
                    Description = $"Description {nameOfCouse1}"
                };

                context.Add<Course>(course_1);

                StudentCourse sc = new StudentCourse()
                {
                    Course = course_1,
                    CourseId = course_1.Id,

                    Student=studentA,
                    StudentId=studentA.Id
                };
                context.Add<StudentCourse>(sc);
            }
            

            //course-2
            Course course_2 = context.Set<Course>().FirstOrDefault(c => c.Name == nameOfCouse2);
            isNeedPersistToDB |= course_2 == null;

            if (course_2 == null)
            {
                course_2 = new Course()
                {
                    Name = nameOfCouse2,
                    Description = $"Description {nameOfCouse2}"
                };

                context.Add<Course>(course_2);

                StudentCourse sc = new StudentCourse()
                {
                    Course = course_2,
                    CourseId = course_2.Id,

                    Student = studentA,
                    StudentId = studentA.Id
                };
                context.Add<StudentCourse>(sc);
            }


            if(isNeedPersistToDB)
                //save at once (bulk)
                context.SaveChanges();
        }

    }
}
