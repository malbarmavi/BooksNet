using BooksNet.Models;
using System.Linq;

namespace BooksNet.Helper
{
  public static class ProfileInfo
  {
    private static Profile _profile { get; set; } = (new ApplicationDbContext()).Profile.FirstOrDefault();

    public static string Name { get; } = _profile.Name;

    public static string Descraption { get; } = _profile.Description;

    public static string Title { get; } = _profile.Title;
  }
}