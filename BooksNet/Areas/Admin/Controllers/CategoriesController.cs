using BooksNet.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  public class CategoriesController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      return View(await db.Categories.Include(c => c.Books).ToListAsync());
    }

    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = await db.Categories.FindAsync(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Name,Version,CreateDate,LastUpdate")] Category category)
    {
      if (ModelState.IsValid)
      {
        category.CreateDate = DateTime.Now;
        category.LastUpdate = DateTime.Now;

        db.Categories.Add(category);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View(category);
    }

    public async Task<ActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = await db.Categories.FindAsync(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Version,CreateDate,LastUpdate")] Category category)
    {
      if (ModelState.IsValid)
      {
        category.LastUpdate = DateTime.Now;
        db.Categories.Attach(category);
        db.Entry(category).Property(c => c.Name).IsModified = true;
        db.Entry(category).Property(c => c.LastUpdate  ).IsModified = true;
        db.Entry(category).Property(c => c.Version).IsModified = true;

        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(category);
    }

    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = await db.Categories.FindAsync(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      Category category = await db.Categories.FindAsync(id);
      db.Categories.Remove(category);
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