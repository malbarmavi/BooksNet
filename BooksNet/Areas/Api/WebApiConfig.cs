using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace BooksNet.Areas.Api
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.Formatters.Clear();
      config.Formatters.Add(new JsonMediaTypeFormatter());

      config.MessageHandlers.Insert(0, 
        new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

      config.MapHttpAttributeRoutes();
      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}