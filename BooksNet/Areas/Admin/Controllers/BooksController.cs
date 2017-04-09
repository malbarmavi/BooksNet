using System;
using BooksNet.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  public class BooksController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      var books = db.Books.Include(b => b.Publisher);
      return View(await books.ToListAsync());
    }

    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Book book = await db.Books.FindAsync(id);
      if (book == null)
      {
        return HttpNotFound();
      }
      return View(book);
    }

    public ActionResult Create()
    {
      ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Title,Age,CategoryId,Print,PrintDate,Notes,PublisherId,FileName,CoverImageName,CreateDate,LastUpdate,PagesNumber,Version,Descriptions")] Book book)
    {
      if (ModelState.IsValid)
      {
        db.Books.Add(book);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
      return View(book);
    }

    public async Task<ActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Book book = await db.Books.FindAsync(id);
      if (book == null)
      {
        return HttpNotFound();
      }
      ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
      return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Age,CategoryId,Print,PrintDate,Notes,PublisherId,FileName,CoverImageName,CreateDate,LastUpdate,PagesNumber,Version,Descriptions")] Book book)
    {
      if (ModelState.IsValid)
      {
        db.Entry(book).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
      return View(book);
    }

    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Book book = await db.Books.FindAsync(id);
      if (book == null)
      {
        return HttpNotFound();
      }
      return View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      Book book = await db.Books.FindAsync(id);
      db.Books.Remove(book);
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