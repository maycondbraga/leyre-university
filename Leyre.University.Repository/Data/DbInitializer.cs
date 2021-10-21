using System;
using System.Linq;
using Leyre.University.Model.Entities;
using Leyre.University.Model.Enums;
using Leyre.University.Repository.Contexts;

namespace Leyre.University.Repository.Data
{
    /// <summary>
    /// Database initialization class
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// If there is no record in the database, it will be created by the initiator
        /// </summary>
        /// <param name="context"> University Context </param>
        public void Initialize(UniversityContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new StudentModel[]
            {
            new StudentModel{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new StudentModel{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentModel{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new StudentModel{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentModel{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentModel{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new StudentModel{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new StudentModel{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (StudentModel s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new CourseModel[]
            {
            new CourseModel{Id=1050,Title="Chemistry",Credits=3},
            new CourseModel{Id=4022,Title="Microeconomics",Credits=3},
            new CourseModel{Id=4041,Title="Macroeconomics",Credits=3},
            new CourseModel{Id=1045,Title="Calculus",Credits=4},
            new CourseModel{Id=3141,Title="Trigonometry",Credits=4},
            new CourseModel{Id=2021,Title="Composition",Credits=3},
            new CourseModel{Id=2042,Title="Literature",Credits=4}
            };
            foreach (CourseModel c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new EnrollmentModel[]
            {
            new EnrollmentModel{StudentId=1,CourseId=1050,Grade=Grade.A},
            new EnrollmentModel{StudentId=1,CourseId=4022,Grade=Grade.C},
            new EnrollmentModel{StudentId=1,CourseId=4041,Grade=Grade.B},
            new EnrollmentModel{StudentId=2,CourseId=1045,Grade=Grade.B},
            new EnrollmentModel{StudentId=2,CourseId=3141,Grade=Grade.F},
            new EnrollmentModel{StudentId=2,CourseId=2021,Grade=Grade.F},
            new EnrollmentModel{StudentId=3,CourseId=1050},
            new EnrollmentModel{StudentId=4,CourseId=1050},
            new EnrollmentModel{StudentId=4,CourseId=4022,Grade=Grade.F},
            new EnrollmentModel{StudentId=5,CourseId=4041,Grade=Grade.C},
            new EnrollmentModel{StudentId=6,CourseId=1045},
            new EnrollmentModel{StudentId=7,CourseId=3141,Grade=Grade.A},
            };
            foreach (EnrollmentModel e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
