using BooksNet.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.ViewModels.Book
{
  public class NewBookViewModel
  {
    [Required]
    public string Title { get; set; }

    [Required]
    public AgeSet Age { get; set; }

 
    public SelectList Category { get; set; }

 
    public int CategoryId { get; set; }

   
    public MultiSelectList Categories { get; set; }

    [Required]
    public int[] CategoriesId { get; set; }

    public string Print { get; set; }

    public string PrintDate { get; set; }

    [MaxLength(250)]
    public string Notes { get; set; }

   
    public MultiSelectList Authors { get; set; }

    [Required]
    public int[] AuthorsId { get; set; }

    public SelectList Publisher { get; set; }

    [Required]
    public int PublisherId { get; set; }

    [Required]
    public HttpPostedFileBase File { get; set; }

    public HttpPostedFileBase CoverImage { get; set; }

    public int PagesNumber { get; set; }

    [MaxLength(500)]
    public string Descriptions { get; set; }
  }
}