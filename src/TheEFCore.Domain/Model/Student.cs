using System;
using System.Collections.Generic;

namespace TheEFCore.Domain.Model
{
    /// <summary>
    /// 1. [One to Many] Student - Grade
    /// 2. [One to One] Student - Address
    /// 3. [Many to Many] Student - Course via StudentCourse
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? GradeId { get; set; }
        public Grade Grade { get; set; }

        public Address Address { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
