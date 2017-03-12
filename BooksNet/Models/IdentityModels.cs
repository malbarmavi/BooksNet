using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BooksNet.Models
{
  public class ApplicationUser : IdentityUser
  {
    [Required]
    [MaxLength(150)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(150)]
    public string LastName { get; set; }

    [MaxLength(250)]
    public string Address { get; set; }

    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Last update happen on the user like update name,email,password
    /// </summary>
    public DateTime UpdateDate { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
  }
}