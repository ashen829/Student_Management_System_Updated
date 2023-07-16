using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Management_System_2
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
 
            optionsBuilder.UseSqlite("Data Source = Data.db");
            optionsBuilder.EnableDetailedErrors();

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Module> Modules { get; set; }

        

    }



}
