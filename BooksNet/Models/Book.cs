using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public class Book
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public AgeSet Age { get; set; }

    
    public Category MainCategory { get; set; }

    [Required]
    public int MainCategoryId { get; set; }

    [Required]
    public List<Category> Subcategories { get; set; }

    [Required]
    public int Print { get; set; }

    public DateTime PublishDate { get; set; }

    [MaxLength(250)]
    public string Notes { get; set; }

    [Required]
    public List<Author> Authors { get; set; }

    public Publisher Publisher { get; set; }

    [Required]
    public int PublisherId { get; set; }

    public string FileName { get; set; }
  }
}