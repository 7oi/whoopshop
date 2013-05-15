namespace Bordspil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Country", "occupierID_UserId", c => c.Int());
            AddForeignKey("dbo.Country", "occupierID_UserId", "dbo.User", "UserId");
            CreateIndex("dbo.Country", "occupierID_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Country", new[] { "occupierID_UserId" });
            DropForeignKey("dbo.Country", "occupierID_UserId", "dbo.User");
            DropColumn("dbo.Country", "occupierID_UserId");
            DropTable("dbo.User");
        }
    }
}
