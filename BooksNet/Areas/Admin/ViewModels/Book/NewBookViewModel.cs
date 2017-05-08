using BooksNet.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace BooksNet.Areas.Admin.ViewModels.Book
{
  public class NewBookViewModel
  {
    [Required]
    [Display(Name = nameof(Title), ResourceType = typeof(GlobalResources.Resource))]
    public string Title { get; set; }

    [Required]
    [Display(Name = nameof(Age), ResourceType = typeof(GlobalResources.Resource))]
    public AgeSet Age { get; set; }

    [Display(Name = nameof(Category), ResourceType = typeof(GlobalResources.Resource))]
    public SelectList Category { get; set; }

    public int CategoryId { get; set; }

    [Display(Name = nameof(Categories), ResourceType = typeof(GlobalResources.Resource))]
    public MultiSelectList Categories { get; set; }

    [Required]
    public int[] CategoriesId { get; set; }

    [Display(Name = nameof(Print), ResourceType = typeof(GlobalResources.Resource))]
    public string Print { get; set; }

    [Display(Name = nameof(PrintDate), ResourceType = typeof(GlobalResources.Resource))]
    public string PrintDate { get; set; }

    [MaxLength(250)]
    [Display(Name = nameof(Notes), ResourceType = typeof(GlobalResources.Resource))]
    public string Notes { get; set; }

    [Display(Name = nameof(Authors), ResourceType = typeof(GlobalResources.Resource))]
    public MultiSelectList Authors { get; set; }

    [Required]
    public int[] AuthorsId { get; set; }

    [Display(Name = nameof(Publisher), ResourceType = typeof(GlobalResources.Resource))]
    public SelectList Publisher { get; set; }

    [Required]
    public int PublisherId { get; set; }

    [Display(Name = nameof(File), ResourceType = typeof(GlobalResources.Resource))]
    public HttpPostedFileBase File { get; set; }

    [Display(Name = nameof(CoverImage), ResourceType = typeof(GlobalResources.Resource))]
    public HttpPostedFileBase CoverImage { get; set; }

    [Display(Name = nameof(PagesNumber), ResourceType = typeof(GlobalResources.Resource))]
    public int PagesNumber { get; set; }

    [MaxLength(500)]
    [Display(Name = nameof(Descriptions), ResourceType = typeof(GlobalResources.Resource))]
    public string Descriptions { get; set; }
  }
}