using BooksNet.Models;
using System.Linq;
using System.Web.Http;

namespace BooksNet.Areas.Api.Controllers
{
  public class LatestUploadController : ApiController
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public IQueryable<Book> GetLatestUpload()
    {
      return db.Books.OrderByDescending(b => b.Id).Take(20);
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