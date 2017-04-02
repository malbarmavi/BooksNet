namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Address", c => c.String());
            AlterColumn("dbo.Publishers", "Address", c => c.String());
            DropColumn("dbo.Authors", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Authors", "FirstName");
        }
    }
}
