using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceConsole.Models;

namespace WebServiceConsole
{

    //grant_type=password&username=jeremy&password=1234567
    //Dans le header Authorization: bearer aefeaoudhazinhaxaef(le token)
    //postman
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9000/"))
            {   
                Console.WriteLine("press enter to exit...");
                Console.ReadLine();
            }
        }
    }
}
