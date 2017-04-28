using System.Web.Mvc;
using System.Web.Routing;

namespace BooksNet
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: "Books",
        url: "Books/{*catchall}",
        defaults: new { controller = "Home", action = "Index" }
      );

      routes.MapRoute(
        name: "Content",
        url: "Content/{*catchall}",
        defaults: new { controller = "Home", action = "Index" }
      );

      routes.MapRoute(
        name: "About",
        url: "About/{*catchall}",
        defaults: new { controller = "Home", action = "Index" }
      );

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}