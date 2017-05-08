using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BooksNet.Areas.Admin.ViewModels.Book
{
  public class EditBookViewModel : NewBookViewModel
  {
    [Required]
    public int Id { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }

    [Display(Name = nameof(File), ResourceType = typeof(GlobalResources.Resource))]
    new public HttpPostedFileBase File { get; set; }
  }
}