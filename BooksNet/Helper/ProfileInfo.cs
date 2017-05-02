using BooksNet.Models;
using System.Linq;

namespace BooksNet.Helper
{
  public static class ProfileInfo
  {
    private static Profile _profile { get; set; } = (new ApplicationDbContext()).Profile.FirstOrDefault();

    public static string Name { get; } = _profile.Name ?? Refrech().Name;

    public static string Descraption { get; } = _profile.Description ?? Refrech().Description;

    public static string Title { get; } = _profile.Title ?? Refrech().Title;

    private static Profile Refrech()
    {
     _profile = (new ApplicationDbContext()).Profile.FirstOrDefault();
      return _profile;
    }
  }
}