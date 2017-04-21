using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BooksNet.Models;
using BooksNet.Areas.Admin.ViewModels.Book;
using System.Collections.Generic;
using System.IO;

namespace BooksNet.Areas.Admin.Controllers
{
  public class BooksController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      var books = db.Books.Include(b => b.Publisher).Include(b => b.Authors);
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
      //ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(NewBookViewModel model)
    {
      if (ModelState.IsValid)
      {
        if (model.File.ContentLength > 0)
        {
          model.File.SaveAs(Path.Combine(Server.MapPath("~/App_Data/BooksFiles"), Path.GetFileName(model.File.FileName))) ;
        }

        if (model.CoverImage?.ContentLength > 0)
        {
          model.CoverImage.SaveAs(Path.Combine(Server.MapPath("~/App_Data/BooksCoverImage"), Path.GetFileName(model.CoverImage.FileName)));
        }

        Book book = new Book();
        book.Title = model.Title;
        book.Age = model.Age;
        book.Descriptions = model.Descriptions;
        book.CategoryId = model.CategoryId;
        book.Authors = db.Authours.Where(a => model.AuthorsId.Contains(a.Id)).ToList();
        book.Categories = db.Categories.Where(c => model.CategoriesId.Contains(c.Id)).ToList();
        book.PublisherId = model.PublisherId;
        book.Print = model.Print;
        book.PrintDate = model.PrintDate;
        book.FileName = model.File.FileName;
        book.CoverImageName = model.CoverImage?.FileName ?? "";
        book.CreateDate = DateTime.Now;
        book.LastUpdate = DateTime.Now;

        db.Books.Add(book);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      var categories = db.Categories.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
      var publishers = db.Publishers.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
      var authours = db.Authours.Select(c => new { Id = c.Id, Name = c.FirstName }).ToList();

      model.Category = new SelectList(categories, "Id", "Name", model.CategoryId);
      model.Categories = new MultiSelectList(categories, "Id", "Name", model.CategoriesId);
      model.Authors = new MultiSelectList(authours, "Id", "Name", model.AuthorsId);
      model.Publisher = new SelectList(publishers, "Id", "Name", model.PublisherId);

      return View(model);
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