using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public class Category
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
  }
}