using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksNet.Models
{
  public class Book
  {
    [Key, Column(Order = 0)]
    public int Id { get; set; }

    [Key, Column(Order = 1)]
    public string Title { get; set; }

    [Required]
    public AgeSet Age { get; set; }

    [Required]
    public Category MainCategory { get; set; }
    
    public int MainCategoryId { get; set; }

    [Required]
    public List<Category> Subcategories { get; set;}

    [Required]
    public int Print { get; set; }

    public DateTime PublishDate { get; set; }

    [MaxLength(250)]
    public string Notes { get; set; }

    public List<Author> Authors { get; set; }
  }
}