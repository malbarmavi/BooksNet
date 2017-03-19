namespace BooksNet.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class AddTimestampToModels : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Authors", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
      AddColumn("dbo.Books", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
      AddColumn("dbo.Categories", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
      AddColumn("dbo.Publishers", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
    }

    public override void Down()
    {
      DropColumn("dbo.Publishers", "Version");
      DropColumn("dbo.Categories", "Version");
      DropColumn("dbo.Books", "Version");
      DropColumn("dbo.Authors", "Version");
    }
  }
}