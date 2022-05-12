using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlabb1.Models
{
    public class Context : DbContext
    {
        public DbSet<Employees> Employee { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-9PE0LLE1\\SQLEXPRESS;Initial Catalog=EFlabb1LeaveApp;Integrated Security=True;");
        }
    }
}
