using System;
using System.ComponentModel.DataAnnotations;

namespace BooksNet.Areas.Admin.ViewModels.Users
{
  public class UserViewModel
  {
    [Required]
    [MaxLength(150)]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(150)]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [MaxLength(250)]
    public string Address { get; set; }

    [Display(Name = "Create date")]
    public DateTime CreateDate { get; set; }

    [Display(Name = "Last update")]
    public DateTime LastUpdate { get; set; }

    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; }

  }
}