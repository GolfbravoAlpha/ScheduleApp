using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Models;

namespace ScheduleApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ScheduleDateAndTime> ScheduleDateAndTimeTbl { get; set; }
        public DbSet<Staff> StaffTbl { get; set; }
        public DbSet<Student> StudentTbl { get; set; }

        public DbSet<staffHoursWorked> staffHoursWorkedTbl { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}
