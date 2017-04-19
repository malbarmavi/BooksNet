using BooksNet.Models;
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
      Book book = await db.Books.FindAsync(id);
      if (book == null)
      {
        return NotFound();
      }

      return Ok(book);
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