using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceConsole.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }

        public User() { }
    }
}
