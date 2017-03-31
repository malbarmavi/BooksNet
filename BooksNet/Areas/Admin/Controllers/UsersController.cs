using BooksNet.Areas.Admin.Models;
using BooksNet.Areas.Admin.ViewModels.Users;
using BooksNet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.Controllers
{
  [Authorize]
  public class UsersController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public async Task<ActionResult> Index()
    {
      return View(await db.Users.ToListAsync());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(NewUserViewModel user)
    {
      if (ModelState.IsValid)
      {
        ApplicationUser admin = new ApplicationUser()
        {
          Email = user.Email,
          UserName = user.Email,
          FirstName = user.FirstName,
          LastName = user.LastName,
          CreateDate = DateTime.Now,
          LastUpdate = DateTime.Now
        };

        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        var result = await userManager.CreateAsync(admin, user.Password);
        if (result.Succeeded)
        {
          userManager.AddToRole(admin.Id, Roles.Admin);
        }
        return RedirectToAction("Index");
      }

      return View(user);
    }

    public async Task<ActionResult> Edit(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      ApplicationUser user = await db.Users.SingleAsync(u => u.Id == id);
      if (user == null)
      {
        return HttpNotFound();
      }
      return View(new EditUserViewModel() {
        Id =user.Id,
        FirstName=user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        Address = user.Address,
        PhoneNumber= user.PhoneNumber,
        Version = user.Version
      });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(EditUserViewModel model)
    {
      if (ModelState.IsValid)
      {

        ApplicationUser user = await db.Users.SingleAsync(u => u.Id == model.Id);
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.UserName = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        user.Address = model.Address;
     
        db.Entry(user).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(model);
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