using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public class Category
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Book> Books { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
  }

}