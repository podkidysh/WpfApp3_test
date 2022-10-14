using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.DB
{
    public class MyContext : DbContext
    {
        private string cs = "server=192.168.10.222;database=Test;user id=test; Password=test";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<User> Users { get; set; }
    }
}
