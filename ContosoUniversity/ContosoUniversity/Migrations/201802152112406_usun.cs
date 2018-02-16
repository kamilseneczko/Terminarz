namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usun : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Actions", new[] { "User_Id" });
            DropTable("dbo.Actions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActionName = c.String(),
                        ActionDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Actions", "User_Id");
            AddForeignKey("dbo.Actions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
