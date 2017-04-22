using BooksNet.Models;
using System.Linq;
using System.Web.Http;

namespace BooksNet.Areas.Api.Controllers
{
  public class TopViewsController : ApiController
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public IQueryable<Book> Get()
    {
      return db.Books.OrderByDescending(b => b.Views).Take(20);
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