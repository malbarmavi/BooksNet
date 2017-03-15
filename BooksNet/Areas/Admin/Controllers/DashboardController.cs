using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  public class DashboardController : Controller
  {
    [Authorize]
    public ActionResult Index()
    {
      return View();
    }
  }
}