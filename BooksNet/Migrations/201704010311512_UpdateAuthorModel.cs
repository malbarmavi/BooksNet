namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthorModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "Pages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Pages", c => c.Int(nullable: false));
        }
    }
}
