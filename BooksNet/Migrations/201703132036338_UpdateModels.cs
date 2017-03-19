namespace BooksNet.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class UpdateModels : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Authors", "Pages", c => c.Int(nullable: false));
      AddColumn("dbo.Authors", "CreateDate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Authors", "LastUpdate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Books", "CreateDate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Books", "LastUpdate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Categories", "CreateDate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Categories", "LastUpdate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Publishers", "CreateDate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Publishers", "LastUpdate", c => c.DateTime(nullable: false));
    }

    public override void Down()
    {
      DropColumn("dbo.Publishers", "LastUpdate");
      DropColumn("dbo.Publishers", "CreateDate");
      DropColumn("dbo.Categories", "LastUpdate");
      DropColumn("dbo.Categories", "CreateDate");
      DropColumn("dbo.Books", "LastUpdate");
      DropColumn("dbo.Books", "CreateDate");
      DropColumn("dbo.Authors", "LastUpdate");
      DropColumn("dbo.Authors", "CreateDate");
      DropColumn("dbo.Authors", "Pages");
    }
  }
}