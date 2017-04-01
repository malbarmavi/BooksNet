namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthorModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "PhoneNumber", c => c.String());
            DropColumn("dbo.Authors", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Mobile", c => c.String());
            DropColumn("dbo.Authors", "PhoneNumber");
        }
    }
}
