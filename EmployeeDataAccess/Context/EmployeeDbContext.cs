using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDataAccess.Entities;

namespace EmployeeDataAccess.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() :
            base("DefaultConnection")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
