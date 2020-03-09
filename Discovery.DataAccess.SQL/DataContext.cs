using Discovery.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Discovery")
        {

        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
