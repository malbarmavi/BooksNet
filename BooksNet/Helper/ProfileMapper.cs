using BooksNet.Models;
using System.Linq;

namespace BooksNet.Helper
{
  public static class ProfileMapper
  {
    private static Profile _profile { get; set; } = (new ApplicationDbContext()).Profile.FirstOrDefault();

    public static Profile Get()
    {
      if (_profile == null)
     _profile = (new ApplicationDbContext()).Profile.FirstOrDefault();
      return _profile;
    }
  }
}