using BooksNet.Areas.Api;
using System;
using System.Globalization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BooksNet
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_BeginRequest()
    {
      HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];

      if (cookie != null && cookie.Value != null)
      {
        CultureInfo culture = new CultureInfo(cookie.Value);

        if (cookie.Value != "en-US")
        {
          culture.DateTimeFormat = new CultureInfo("en-US").DateTimeFormat;
        }

        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
      }
      else
      {
        cookie = new HttpCookie("Language", "ar-SY")
        {
          Expires = DateTime.Now.AddYears(1)
        };

        Response.Cookies.Add(cookie);
        CultureInfo culture = new CultureInfo(cookie.Value);

        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
      }
    }

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
  }
}