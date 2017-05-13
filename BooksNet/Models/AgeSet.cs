using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public enum AgeSet : int
  {
    [Display(Name = "AllAges", ResourceType = typeof(GlobalResources.Resource))]
    All = 0,
    [Display(Name = "Adults", ResourceType = typeof(GlobalResources.Resource))]
    Adults = 1,
    [Display(Name = "Kids", ResourceType = typeof(GlobalResources.Resource))]
    Kids = 2
  }
}