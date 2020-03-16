namespace Discovery.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Degree = c.String(),
                        Disability_Type = c.String(),
                        ClassRoom = c.String(),
                        TeacherId = c.String(maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        ClassRoom = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Street = c.String(),
                        Job = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Child_Weekly_Report = c.String(),
                        ChildId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Children", t => t.ChildId)
                .ForeignKey("dbo.NurseryUsers", t => t.UserId)
                .Index(t => t.ChildId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NurseryUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        asp_User_ID = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "UserId", "dbo.NurseryUsers");
            DropForeignKey("dbo.Parents", "ChildId", "dbo.Children");
            DropForeignKey("dbo.Children", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Parents", new[] { "UserId" });
            DropIndex("dbo.Parents", new[] { "ChildId" });
            DropIndex("dbo.Children", new[] { "TeacherId" });
            DropTable("dbo.NurseryUsers");
            DropTable("dbo.Parents");
            DropTable("dbo.Employees");
            DropTable("dbo.Teachers");
            DropTable("dbo.Children");
        }
    }
}
