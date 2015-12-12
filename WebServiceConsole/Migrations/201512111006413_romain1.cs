namespace WebServiceConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class romain1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsTaskOver = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoTasks", "User_Id", "dbo.Users");
            DropIndex("dbo.TodoTasks", new[] { "User_Id" });
            DropTable("dbo.TodoTasks");
        }
    }
}
