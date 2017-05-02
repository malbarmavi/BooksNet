using BooksNet.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BooksNet.Areas.Api.Controllers
{
  public class BooksController : ApiController
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public IQueryable<Book> GetBooks()
    {
      return db.Books;
    }

    [ResponseType(typeof(Book))]
    public async Task<IHttpActionResult> GetBook(int id)
    {
      Book book = await db.Books.Include(b => b.Publisher).Include(b => b.Authors).Include(b => b.Categories).FirstAsync(b => b.Id == id);
      if (book == null)
      {
        return NotFound();
      }

      book.Views += 1;
      db.Entry(book).Property(b => b.Views).IsModified = true;
      db.SaveChanges();

      var result = new
      {
        Title = book.Title,
        Description = book.Descriptions,
        PagesNumber = book.PagesNumber,
        Authors = book.Authors.Select(a => new { Name = $"{a.FirstName} {a.LastName}" }).ToArray(),
        Publisher = book.Publisher.Name,
        Downloads = book.Downloads,
        Views = book.Views,
        CoverImageName = book.CoverImageName,
        FileName = book.FileName
      };

      return Ok(result);
    }

    private bool BookExists(int id)
    {
      return db.Books.Count(e => e.Id == id) > 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}