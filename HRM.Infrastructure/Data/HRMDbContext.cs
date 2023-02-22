using Microsoft.EntityFrameworkCore;
//The DbContext class is an integral part of Entity Framework. An instance of DbContext represents a session with the database which
//can be used to query and save instances of your entities to a database. DbContext is a combination of the Unit Of Work and Repository
//patterns.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.ApplicationCore.Entity;

namespace HRM.Infrastructure.Data
{
    public class HRMDbContext : DbContext //connections will be handled by Dbcontext
    {
        public HRMDbContext(DbContextOptions<HRMDbContext> options) : base (options)
        {
            
        }
        //Dbset is like a table
        //A DbSet represents the collection of all entities in the context, or that can be queried from the database, of a given type.
        //DbSet objects are created from a DbContext using the DbContext.
        public DbSet<JobRequirement> JobRequirement { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Submission> Submission { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewType> InterviewType { get; set; }
        public DbSet<InterviewStatus> InterviewStatus { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeRole> EmployeeRole { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
