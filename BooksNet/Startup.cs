using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksNet.Startup))]

namespace BooksNet
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}