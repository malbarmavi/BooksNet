using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public class Author
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    public string Mobile { get; set; }

    public string Email { get; set; }

    public List<Book> Books { get; set; }
  }
}