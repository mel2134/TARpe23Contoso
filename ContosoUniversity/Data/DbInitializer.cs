using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[] {
                new Student { FirstMidName = "Mel", LastName = "Kosk", EnrollmentDate = DateTime.Parse("2069-06-09") },
                new Student { FirstMidName = "Mered", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "An", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gutis", LastName = "Ganzales", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yai", LastName = "Lin", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Nor", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Niro", LastName = "Olivero", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Carlson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2002-09-01") }
                };
            context.Students.AddRange(students);
            context.SaveChanges();

            if (context.Courses.Any())
            {
                return;
            }
            var courses = new Course[]
            {
                new Course{CourseID=4444,Title="Math",Credits=3},
                new Course{CourseID=2133,Title="Physics",Credits=4},
                new Course{CourseID=5612,Title="Chemistry",Credits=3},
                new Course{CourseID=9021,Title="Science",Credits=3},
                new Course{CourseID=5812,Title="Kirjandus",Credits=4},
                new Course{CourseID=1280,Title="Inglise keel",Credits=3},
                new Course{CourseID=8129,Title="Aine2",Credits=1},
                new Course{CourseID=8915,Title="Progammeerimine",Credits=4}
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            if (context.Enrollments.Any())
            {
                return;
            }
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=8915,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=1280,Grade=Grade.A},

                new Enrollment{StudentID=2,CourseID=1280,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=8129,Grade=Grade.B},

                new Enrollment{StudentID=3,CourseID=8915,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=4444},

                new Enrollment{StudentID=4,CourseID=2133},
                new Enrollment{StudentID=4,CourseID=9021,Grade=Grade.D},

                new Enrollment{StudentID=5,CourseID=5612,Grade=Grade.A},
                new Enrollment{StudentID=5,CourseID=1280,Grade=Grade.D},

                new Enrollment{StudentID=6,CourseID=2133},

                new Enrollment{StudentID=7,CourseID=5812,Grade=Grade.A},

                new Enrollment{StudentID=8,CourseID=5612,Grade=Grade.F},
                new Enrollment{StudentID=8,CourseID=9021,Grade=Grade.F},

                new Enrollment{StudentID=10,CourseID=1280,Grade=Grade.B},
                new Enrollment{StudentID=10,CourseID=4444,Grade=Grade.D}
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();


            if (context.Instructors.Any())
            {
                return;
            }
            var instructors = new Instructor[]
            {
                new Instructor{FirstMidName = "Ying", LastName = "Yang", DaysOff = 0, HireDate = DateTime.Parse("2019-09-01")},
                new Instructor{FirstMidName = "Original", LastName = "Name", DaysOff = 2, HireDate = DateTime.Parse("1776-09-01")},
                new Instructor{FirstMidName = "This", LastName = "One", DaysOff = 9123, HireDate = DateTime.Parse("1776-09-01")},
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();


            if (context.Departments.Any())
            {
                return;
            }
            var departments = new Department[]
            {
                new Department{
                    Name="IT",
                    Budget=0,
                    StartDate=DateTime.Parse("1999-09-09"),
                    InstructorID=1,
                    SuperImportantString="ashydasnhdhjanjd shua",
                },
                new Department{
                    Name="Language",
                    Budget=0,
                    StartDate=DateTime.Parse("2000-01-01"),
                    InstructorID=1,
                    SuperImportantString="ggghbnjmkl,aszxdcrfvgbhnjmk,2",
                },
                new Department{
                    Name="Everything else",
                    Budget=0,
                    StartDate=DateTime.Parse("3000-01-01"),
                    SuperImportantString="gfsdfshiASYDWEWiuwyrgctI12387646yiusabgdgy",
                },
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
            /*
            context.Database.EnsureCreated();
            
            //
            if (context.Students.Any())
            {
                return;
            }
            
            //õpilaste object
            var students = new Student[]
            {
                new Student{FirstMidName="Mel",LastName="Kosk",EnrollmentDate=DateTime.Parse("2069-06-09")},
                new Student{FirstMidName="Mered",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="An",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gutis",LastName="Ganzales",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yai",LastName="Lin",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Nor",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Niro",LastName="Olivero",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Carlson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2002-09-01")},

            };
            //lisame iga õpilase
            foreach (Student student in students)
            {
                context.Students.Add(student);
            }
            //salvestame
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course{CourseID=4444,Title="Math",Credits=3},
                new Course{CourseID=2133,Title="Physics",Credits=4},
                new Course{CourseID=5612,Title="Chemistry",Credits=3},
                new Course{CourseID=9021,Title="Science",Credits=3},
                new Course{CourseID=5812,Title="Kirjandus",Credits=4},
                new Course{CourseID=1280,Title="Inglise keel",Credits=3},
                new Course{CourseID=8129,Title="Aine2",Credits=1},
                new Course{CourseID=8915,Title="Progammeerimine",Credits=4},
            };
            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=8915,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=1280,Grade=Grade.A},

                new Enrollment{StudentID=2,CourseID=1280,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=8129,Grade=Grade.B},

                new Enrollment{StudentID=3,CourseID=8915,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=4444},

                new Enrollment{StudentID=4,CourseID=2133},
                new Enrollment{StudentID=4,CourseID=9021,Grade=Grade.D},

                new Enrollment{StudentID=5,CourseID=5612,Grade=Grade.A},
                new Enrollment{StudentID=5,CourseID=1280,Grade=Grade.D},

                new Enrollment{StudentID=6,CourseID=2133},

                new Enrollment{StudentID=7,CourseID=5812,Grade=Grade.A},

                new Enrollment{StudentID=8,CourseID=5612,Grade=Grade.F},
                new Enrollment{StudentID=8,CourseID=9021,Grade=Grade.F},

                new Enrollment{StudentID=10,CourseID=1280,Grade=Grade.B},
                new Enrollment{StudentID=10,CourseID=4444,Grade=Grade.D},
            };
            foreach (Enrollment enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }
            context.SaveChanges();
            */

        }
    }
}