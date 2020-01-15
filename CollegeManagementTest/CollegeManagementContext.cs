using System;
using CollegeManagementTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CollegeManagementTest.Models.DTO;

namespace CollegeManagementTest
{
    public class CollegeManagementContext : DbContext
    {
        public CollegeManagementContext(DbContextOptions<CollegeManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }
    }
}
