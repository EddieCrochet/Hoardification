using SPCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPCollege.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            //Look for any students
            if (context.Students.Any())
            {
                return; //DB has been seeded
            }

            var students = new Student[]
            {
                new Student{LastName="Bane", FirstName="Joey", EnrollmentDate=DateTime.Now },
                new Student{LastName="Brune", FirstName="Jins", EnrollmentDate=DateTime.Now },
                new Student{LastName="drune", FirstName="moey", EnrollmentDate=DateTime.Now },
                new Student{LastName="dane", FirstName="gey", EnrollmentDate=DateTime.Now },
                new Student{LastName="hane", FirstName="zey", EnrollmentDate=DateTime.Now },
                new Student{LastName="zane", FirstName="zoey", EnrollmentDate=DateTime.Now }
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            var courses = new Course[]
            {
                new Course{CourseID=331, Title="JavaScript", Credits=3},
                new Course{CourseID=131, Title="C#", Credits=3},
                new Course{CourseID=341, Title="Python", Credits=3},
                new Course{CourseID=221, Title="Java", Credits=3},
                new Course{CourseID=441, Title="Linux", Credits=3},
                new Course{CourseID=351, Title="Angular", Credits=3},
                new Course{CourseID=111, Title="React", Credits=3},
            };
            foreach (Course s in courses)
            {
                context.Courses.Add(s);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=441, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=331, Grade=Grade.B},
                new Enrollment{StudentID=3, CourseID=351, Grade=Grade.A},
                new Enrollment{StudentID=4, CourseID=111, Grade=Grade.C},
                new Enrollment{StudentID=1, CourseID=111, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=111, Grade=Grade.F},
                new Enrollment{StudentID=3, CourseID=111, Grade=Grade.F},
                new Enrollment{StudentID=4, CourseID=351, Grade=Grade.A}
            };
            foreach (Enrollment s in enrollments)
            {
                context.Enrollments.Add(s);
            }
            context.SaveChanges();
        }
    }
}

