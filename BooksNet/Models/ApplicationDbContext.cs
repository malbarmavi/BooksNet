using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BooksNet.Models
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Author> Authours { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext()
        : base("BooksNetDataBae", throwIfV1Schema: false)
    {
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}