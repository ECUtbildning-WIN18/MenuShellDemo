using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShellDemo.Domain
{
    class MenuShellDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MenuShellDbContext() : base("MenuShellDbContext")
        {
        }
    }
}
