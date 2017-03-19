namespace BooksNet.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class UpdateBookModel : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Books", "PagesNumber", c => c.Int(nullable: false));
    }

    public override void Down()
    {
      DropColumn("dbo.Books", "PagesNumber");
    }
  }
}