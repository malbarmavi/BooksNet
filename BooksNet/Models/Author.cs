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
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    
    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public List<Book> Books { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastUpdate { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
  }
}