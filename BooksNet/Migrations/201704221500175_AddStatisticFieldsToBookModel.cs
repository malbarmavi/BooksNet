namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatisticFieldsToBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Downloads", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Downloads");
            DropColumn("dbo.Books", "Views");
        }
    }
}
