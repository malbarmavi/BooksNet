using BooksNet.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace BooksNet.Areas.Api.Controllers
{
  public class BooksSearchController : ApiController
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public IEnumerable<Book> GetBooksSearch([FromUri]BooksSearchData searchData)
    {
      var result = db.Books.Include(b => b.Categories).Include(b => b.Authors).Include(b => b.Publisher);

      if (searchData.Title != null)
      {
        result = result.Where(b => b.Title.Contains(searchData.Title));
      }

      if (searchData.Age != 0)
      {
        result = result.Where(b => (int)b.Age == searchData.Age);
      }

      if (searchData.Category != 0)
      {
        result = result.Where(b => b.CategoryId == searchData.Category);
      }

      if (searchData.Categories != null)
      {
        result = result.Where(b => b.Categories.Any(c => searchData.Categories.Contains(c.Id)));
      }

      if (searchData.Authors != null)
      {
        result = result.Where(b => b.Authors.Any(a => searchData.Authors.Contains(a.Id)));
      }

      if (searchData.Publisher != 0)
      {
        result = result.Where(b => b.PublisherId == searchData.Publisher);
      }

      if (searchData.Print != null)
      {
        result = result.Where(b => b.Print == searchData.Print);
      }

      if (searchData.PrintDate != null)
      {
        result = result.Where(b => b.Print == searchData.PrintDate);
      }

      var finalResult = new List<Book>();

      foreach (Book b in result.ToList())
      {
        finalResult.Add(new Book() {
          Title = b.Title,
          CoverImageName = b.CoverImageName , 
          FileName = b.FileName,
        });
      }

      return finalResult;
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