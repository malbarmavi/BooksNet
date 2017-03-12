namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 250));
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Version");
            DropColumn("dbo.AspNetUsers", "LastUpdate");
            DropColumn("dbo.AspNetUsers", "CreateDate");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
