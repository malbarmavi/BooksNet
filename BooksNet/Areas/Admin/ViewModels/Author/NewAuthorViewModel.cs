using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksNet.Areas.Admin.ViewModels.Author
{
  public class NewAuthorViewModel
  {
    [Required]
    [MaxLength(150)]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(150)]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [EmailAddress]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [MaxLength(250)]
    public string Address { get; set; }

    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; }
  }
}