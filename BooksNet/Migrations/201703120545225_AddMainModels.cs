namespace BooksNet.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class AddMainModels : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.Authors",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false),
            LastName = c.String(nullable: false),
            Address = c.String(nullable: false),
            Mobile = c.String(),
            Email = c.String(),
          })
          .PrimaryKey(t => t.Id);

      CreateTable(
          "dbo.Books",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Title = c.String(nullable: false),
            Age = c.Int(nullable: false),
            CategoryId = c.Int(nullable: false),
            Print = c.Int(nullable: false),
            PublishDate = c.DateTime(nullable: false),
            Notes = c.String(maxLength: 250),
            PublisherId = c.Int(nullable: false),
            FileName = c.String(),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
          .Index(t => t.PublisherId);

      CreateTable(
          "dbo.Categories",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Name = c.String(),
          })
          .PrimaryKey(t => t.Id);

      CreateTable(
          "dbo.Publishers",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false),
            Address = c.String(nullable: false),
          })
          .PrimaryKey(t => t.Id);

      CreateTable(
          "dbo.BookAuthors",
          c => new
          {
            Book_Id = c.Int(nullable: false),
            Author_Id = c.Int(nullable: false),
          })
          .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
          .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
          .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
          .Index(t => t.Book_Id)
          .Index(t => t.Author_Id);

      CreateTable(
          "dbo.CategoryBooks",
          c => new
          {
            Category_Id = c.Int(nullable: false),
            Book_Id = c.Int(nullable: false),
          })
          .PrimaryKey(t => new { t.Category_Id, t.Book_Id })
          .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
          .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
          .Index(t => t.Category_Id)
          .Index(t => t.Book_Id);
    }

    public override void Down()
    {
      DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
      DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
      DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
      DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
      DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
      DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
      DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
      DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
      DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
      DropIndex("dbo.Books", new[] { "PublisherId" });
      DropTable("dbo.CategoryBooks");
      DropTable("dbo.BookAuthors");
      DropTable("dbo.Publishers");
      DropTable("dbo.Categories");
      DropTable("dbo.Books");
      DropTable("dbo.Authors");
    }
  }
}