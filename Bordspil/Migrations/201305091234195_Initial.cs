namespace Bordspil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Country", "occupierID_UserId", c => c.Int());
            AddForeignKey("dbo.Country", "occupierID_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Country", "occupierID_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Country", new[] { "occupierID_UserId" });
            DropForeignKey("dbo.Country", "occupierID_UserId", "dbo.UserProfile");
            DropColumn("dbo.Country", "occupierID_UserId");
            DropTable("dbo.UserProfile");
        }
    }
}
