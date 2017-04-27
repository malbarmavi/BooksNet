using System.Reflection;
using System.Web.Mvc;

namespace BooksNet.Attributes
{
  public class AjaxOnly : ActionMethodSelectorAttribute
  {
    public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
    {
      return controllerContext.HttpContext.Request.IsAjaxRequest();
    }
  }
}