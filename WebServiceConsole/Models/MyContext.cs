using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceConsole.Models;

namespace WebServiceConsole
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
