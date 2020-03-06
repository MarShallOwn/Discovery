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
                        SurName = c.String(),
                        Age = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Degree = c.String(),
                        Disability_Type = c.String(),
                        ClassRoom = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        TeacherId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId_Id)
                .Index(t => t.TeacherId_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
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
                        FirstName = c.String(),
                        SurName = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Child_Weekly_Report = c.String(),
                        UserId = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Child_Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Children", t => t.Child_Id_Id)
                .Index(t => t.Child_Id_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "Child_Id_Id", "dbo.Children");
            DropForeignKey("dbo.Children", "TeacherId_Id", "dbo.Teachers");
            DropIndex("dbo.Parents", new[] { "Child_Id_Id" });
            DropIndex("dbo.Children", new[] { "TeacherId_Id" });
            DropTable("dbo.Parents");
            DropTable("dbo.Employees");
            DropTable("dbo.Teachers");
            DropTable("dbo.Children");
        }
    }
}
