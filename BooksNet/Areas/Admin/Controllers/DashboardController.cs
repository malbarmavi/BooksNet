using BooksNet.Areas.Admin.ViewModels.Dashboard;
using BooksNet.Models;
using System.Web.Mvc;
using System.Linq;

namespace BooksNet.Areas.Admin.Controllers
{
  public class DashboardController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    [Authorize]
    public ActionResult Index()
    {
      DashboardViewModel model = new DashboardViewModel();

      model.UsersCount = db.Users.Count();
      model.AuthorsCount= db.Authours.Count();
      model.PublishersCount = db.Publishers.Count();
      model.CategoriesCount = db.Categories.Count();
      model.BooksCount = db.Books.Count();

      return View(model);
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