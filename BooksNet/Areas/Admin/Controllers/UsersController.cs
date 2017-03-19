using BooksNet.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  public class UsersController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      return View(await db.Users.ToListAsync());
    }

    public async Task<ActionResult> Details(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      ApplicationUser applicationUser = await db.Users.SingleAsync(u => u.Id == id);
      if (applicationUser == null)
      {
        return HttpNotFound();
      }
      return View(applicationUser);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ApplicationUser applicationUser)
    {
      if (ModelState.IsValid)
      {
        db.Users.Add(applicationUser);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View(applicationUser);
    }

    public async Task<ActionResult> Edit(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      ApplicationUser applicationUser = await db.Users.SingleAsync(u => u.Id == id);
      if (applicationUser == null)
      {
        return HttpNotFound();
      }
      return View(applicationUser);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(ApplicationUser applicationUser)
    {
      if (ModelState.IsValid)
      {
        db.Entry(applicationUser).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(applicationUser);
    }

    public async Task<ActionResult> Delete(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      ApplicationUser applicationUser = await db.Users.SingleAsync(u => u.Id == id);
      if (applicationUser == null)
      {
        return HttpNotFound();
      }
      return View(applicationUser);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(string id)
    {
      ApplicationUser applicationUser = await db.Users.SingleAsync(u => u.Id == id);
      db.Users.Remove(applicationUser);
      await db.SaveChangesAsync();
      return RedirectToAction("Index");
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