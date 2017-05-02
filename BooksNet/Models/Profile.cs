using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksNet.Models
{
  public class Profile
  {

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string AboutUs { get; set; }

    public string Emails { get; set; }

    public string Address { get; set; }

    public string Phones { get; set; }

    public string Logo { get; set; }

    public string Title { get; set; }

  }
}