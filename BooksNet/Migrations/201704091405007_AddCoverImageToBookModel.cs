namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoverImageToBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CoverImageName", c => c.String());
            AlterColumn("dbo.Books", "FileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "FileName", c => c.String());
            DropColumn("dbo.Books", "CoverImageName");
        }
    }
}
