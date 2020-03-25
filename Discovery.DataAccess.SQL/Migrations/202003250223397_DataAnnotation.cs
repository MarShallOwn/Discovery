namespace Discovery.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NurseryUsers", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.NurseryUsers", "LastName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.NurseryUsers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.NurseryUsers", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.NurseryUsers", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NurseryUsers", "City", c => c.String());
            AlterColumn("dbo.NurseryUsers", "Street", c => c.String());
            AlterColumn("dbo.NurseryUsers", "Email", c => c.String());
            AlterColumn("dbo.NurseryUsers", "LastName", c => c.String());
            AlterColumn("dbo.NurseryUsers", "FirstName", c => c.String());
        }
    }
}
