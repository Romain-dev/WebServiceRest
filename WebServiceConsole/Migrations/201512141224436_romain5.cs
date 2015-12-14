namespace WebServiceConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class romain5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoTasks", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoTasks", "Description");
        }
    }
}
