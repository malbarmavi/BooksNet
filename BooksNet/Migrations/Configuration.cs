namespace BooksNet.Migrations
{
  using BooksNet.Models;
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(ApplicationDbContext context)
    {
    }
  }
}