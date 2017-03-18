namespace BooksNet.Areas.Admin.Models
{
  public static class Roles
  {
    public static string Admin { get; set; } = nameof(Admin);

    public static string SubAdmin { get; set; } = nameof(SubAdmin);

    public static string Staff { get; set; } = nameof(Staff);
  }
}