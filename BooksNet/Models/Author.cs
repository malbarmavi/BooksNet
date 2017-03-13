using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public class Author
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    public string Mobile { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public List<Book> Books { get; set; }

    public int Pages { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastUpdate { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
  }
}