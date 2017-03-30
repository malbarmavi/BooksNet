using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BooksNet
{
  public static class AppSettings
  {
    // get build number
    public static string Build { get; } = Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
  }
}