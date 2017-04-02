using BooksNet.Areas.Admin.ViewModels.Author;
using BooksNet.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  public class AuthorsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      return View(await db.Authours.Include(a => a.Books).ToListAsync());
    }

    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Author author = await db.Authours.FindAsync(id);
      if (author == null)
      {
        return HttpNotFound();
      }
      return View(author);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(NewAuthorViewModel model)
    {
      if (ModelState.IsValid)
      {
        db.Authours.Add(new Author()
        {
          Name = model.FirstName,
          LastName = model.LastName,
          Email = model.Email,
          Address = model.Address,
          PhoneNumber = model.PhoneNumber,
          CreateDate = DateTime.Now,
          LastUpdate = DateTime.Now
        });
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
      Author author = await db.Authours.FindAsync(id);
      if (author == null)
      {
        return HttpNotFound();
      }
      return View(author);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Name,LastName,Address,Mobile,Email,CreateDate,LastUpdate,Version")] Author author)
    {
      if (ModelState.IsValid)
      {
        db.Entry(author).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(author);
    }

    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Author author = await db.Authours.FindAsync(id);
      if (author == null)
      {
        return HttpNotFound();
      }
      return View(author);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      Author author = await db.Authours.FindAsync(id);
      db.Authours.Remove(author);
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