using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagementTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CollegeManagementTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    Seed(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // This method gets called in Main. It seeds the database.
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new CollegeManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CollegeManagementContext>>()))
            {
                //check if database is already seeded
                if(context.Student.Any())
                {
                    return;
                }

                #region Students
                var student1 = new Student
                {
                    Name = "Anjeni",
                    Birthday = new DateTime(1994, 3, 17),
                    RegistrationNumber = 1001
                };

                var student2 = new Student
                {
                    Name = "Yuna",
                    Birthday = new DateTime(1991, 4, 19),
                    RegistrationNumber = 1002
                };

                var student3 = new Student
                {
                    Name = "Ricardo",
                    Birthday = new DateTime(1994, 3, 17),
                    RegistrationNumber = 1003
                };

                var student4 = new Student
                {
                    Name = "Pedro",
                    Birthday = new DateTime(1994, 1, 7),
                    RegistrationNumber = 1004
                };
                #endregion

                #region Teachers
                var teacher1 = new Teacher
                {
                    Name = "Pedro Pereira",
                    Birthday = new DateTime(1971, 7, 15),
                    Salary = "2.000,00€"
                };

                var teacher2 = new Teacher
                {
                    Name = "Paulo Pereira",
                    Birthday = new DateTime(1986, 12, 9),
                    Salary = "2.000,00€"
                };

                var teacher3 = new Teacher
                {
                    Name = "Hernâni Sarrabulho",
                    Birthday = new DateTime(1952, 9, 3),
                    Salary = "4.000,00€"
                };
                #endregion

                #region Courses
                var course1 = new Course
                {
                    Name = "Computer Science",
                };
                var course2 = new Course
                {
                    Name = "Mathematics",
                };
                #endregion

                #region Subject
                var subject1 = new Subject
                {
                    Name = "MATH1",
                    Teacher = teacher1
                };

                var subject2 = new Subject
                {
                    Name = "MATH2",
                    Teacher = teacher2
                };

                var subject3 = new Subject
                {
                    Name = "PROGRAMMING1",
                    Teacher = teacher3
                };
                #endregion

                #region CourseSubject
                var courseSubject1 =
                    new CourseSubject
                    {
                        Course = course1,
                        Subject = subject1
                    };
                var courseSubject2 =
                    new CourseSubject
                    {
                        Course = course1,
                        Subject = subject3
                    };
                var courseSubject3 =
                    new CourseSubject
                    {
                        Course = course2,
                        Subject = subject1
                    };
                var courseSubject4 =
                    new CourseSubject
                    {
                        Course = course2,
                        Subject = subject2
                    };
                #endregion

                #region Grade

                var grade1 = new Grade
                {
                    Value = 15,
                    Student = student1,
                    Subject = subject1
                };
                var grade2 = new Grade
                {
                    Value = 14,
                    Student = student1,
                    Subject = subject2
                };
                var grade3 = new Grade
                {
                    Value = 13,
                    Student = student2,
                    Subject = subject1
                };
                var grade4 = new Grade
                {
                    Value = 13,
                    Student = student2,
                    Subject = subject2
                };
                var grade5 = new Grade
                {
                    Value = 13,
                    Student = student3,
                    Subject = subject1
                };
                var grade6 = new Grade
                {
                    Value = 14,
                    Student = student3,
                    Subject = subject3
                };
                var grade7 = new Grade
                {
                    Value = 15,
                    Student = student4,
                    Subject = subject1
                };
                var grade8 = new Grade
                {
                    Value = 12,
                    Student = student4,
                    Subject = subject3
                };
                #endregion

                //Connect entities
                student1.Grades = new List<Grade>() { grade1, grade2 };
                student2.Grades = new List<Grade>() { grade3, grade4 };
                student3.Grades = new List<Grade>() { grade5, grade6 };
                student4.Grades = new List<Grade>() { grade7, grade8 };

                context.Student.AddRange(student1, student2, student3, student4);
                context.Teacher.AddRange(teacher1, teacher2, teacher3);
                context.Course.AddRange(course1, course2);
                context.Subject.AddRange(subject1, subject2, subject3);
                context.CourseSubjects.AddRange(courseSubject1, courseSubject2, courseSubject3, courseSubject4);
                context.Grade.AddRange(grade1, grade2, grade3, grade4, grade5, grade6, grade7, grade8);

                context.SaveChanges();
            }
        }
    }
}
