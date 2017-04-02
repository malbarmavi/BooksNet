using System.ComponentModel.DataAnnotations;

namespace BooksNet.Areas.Admin.ViewModels.Publisher
{
  public class EditPublisherViewModel : NewPublisherViewModel
  {
    [Required]
    public int Id { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
  }
}