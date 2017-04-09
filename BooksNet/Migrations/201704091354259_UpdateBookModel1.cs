namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PrintDate", c => c.String());
            AddColumn("dbo.Books", "Descriptions", c => c.String(maxLength: 500));
            AlterColumn("dbo.Books", "Print", c => c.String());
            DropColumn("dbo.Books", "PublishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Print", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Descriptions");
            DropColumn("dbo.Books", "PrintDate");
        }
    }
}
