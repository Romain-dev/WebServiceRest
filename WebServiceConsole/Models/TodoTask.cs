using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceConsole.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public User User { get; set; }
        public bool IsTaskOver { get; set; }

        public TodoTask()
        {
            IsTaskOver = false;
        }
    }
}
