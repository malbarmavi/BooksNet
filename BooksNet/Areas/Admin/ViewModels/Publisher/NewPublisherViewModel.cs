using System.ComponentModel.DataAnnotations;

namespace BooksNet.Areas.Admin.ViewModels.Publisher
{
  public class NewPublisherViewModel
  {
    [Required]
    public string Name { get; set; }

    public string Address { get; set; }
  }
}