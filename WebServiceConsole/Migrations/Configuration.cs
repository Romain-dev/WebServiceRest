namespace WebServiceConsole.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebServiceConsole.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebServiceConsole.MyContext context)
        {
            context.Users.AddOrUpdate(
                  p => p.Name,
                  new User { Name = "Romain",Password="Password" }
                  );

            context.TodoTasks.AddOrUpdate(
               p => p.Title,
               new TodoTask { Title = "C#", IsTaskOver = false},
               new TodoTask { Title = "Anglais", IsTaskOver = false },
               new TodoTask { Title = "Android", IsTaskOver = false },
               new TodoTask { Title = "Informatique parallele", IsTaskOver = false }
               );
            //
        }
    }
}
