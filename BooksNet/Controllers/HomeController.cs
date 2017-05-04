using BooksNet.Areas.Admin.ViewModels.Book;
using BooksNet.Attributes;
using BooksNet.Models;
using System.Linq;
using System.Web.Mvc;

namespace BooksNet.Controllers
{
  public class HomeController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
      return View();
    }

    [AjaxOnly]
    public ActionResult About()
    {
      return View();
    }

    [AjaxOnly]

    public ActionResult Contact()
    {
      return View();
    }

    [AjaxOnly]
    public ActionResult Books()
    {
      NewBookViewModel model = new NewBookViewModel();
      var categories = db.Categories.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
      var publishers = db.Publishers.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
      var authours = db.Authours.Select(c => new { Id = c.Id, Name = c.FirstName }).ToList();

      model.Category = new SelectList(categories, "Id", "Name");
      model.Categories = new MultiSelectList(categories, "Id", "Name");
      model.Authors = new MultiSelectList(authours, "Id", "Name");
      model.Publisher = new SelectList(publishers, "Id", "Name");

      return View(model);
    }

    [AjaxOnly]
    public ActionResult Main ()
    {
      return View();
    }

    [AjaxOnly]
    public ActionResult BookDetails ()
    {
      return View();
    }
  }
}