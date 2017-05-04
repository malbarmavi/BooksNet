namespace BooksNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocialLinkToProfileModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Facebook", c => c.String());
            AddColumn("dbo.Profiles", "Twitter", c => c.String());
            AddColumn("dbo.Profiles", "Instagram", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Instagram");
            DropColumn("dbo.Profiles", "Twitter");
            DropColumn("dbo.Profiles", "Facebook");
        }
    }
}
