using BooksNet.Areas.Admin.ViewModels.Publisher;
using BooksNet.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  public class PublishersController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      return View(await db.Publishers.Include(p => p.Books).ToListAsync());
    }

    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Publisher publisher = await db.Publishers.FindAsync(id);
      if (publisher == null)
      {
        return HttpNotFound();
      }
      return View(publisher);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(NewPublisherViewModel model)
    {
      if (ModelState.IsValid)
      {
        Publisher publisher = new Publisher()
        {
          Name = model.Name,
          Address = model.Address,
          CreateDate = DateTime.Now,
          LastUpdate = DateTime.Now
        };

        db.Publishers.Add(publisher);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View(model);
    }

    public async Task<ActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Publisher publisher = await db.Publishers.FindAsync(id);
      if (publisher == null)
      {
        return HttpNotFound();
      }
      return View(publisher);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(EditPublisherViewModel model)
    {
      if (ModelState.IsValid)
      {
        Publisher publisher = await db.Publishers.SingleAsync(p => p.Id == model.Id);
        publisher.Name = model.Name;
        publisher.Address = model.Address;
        db.Entry(publisher).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(model);
    }

    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Publisher publisher = await db.Publishers.FindAsync(id);
      if (publisher == null)
      {
        return HttpNotFound();
      }
      return View(publisher);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      Publisher publisher = await db.Publishers.FindAsync(id);
      db.Publishers.Remove(publisher);
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