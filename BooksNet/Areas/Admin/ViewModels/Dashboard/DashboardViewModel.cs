using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksNet.Areas.Admin.ViewModels.Dashboard
{
  public class DashboardViewModel
  {
    public int UsersCount { get; set; }

    public int AuthorsCount { get; set; }

    public int PublishersCount { get; set; }

    public int CategoriesCount { get; set; }

    public int BooksCount { get; set; }
  }
}