using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public enum AgeSet : int
  {
    [Display(Name = "AllAges", ResourceType = typeof(GlobalResources.Resource))]
    All = 0,
    Adults = 1,
    Kids = 2
  }
}