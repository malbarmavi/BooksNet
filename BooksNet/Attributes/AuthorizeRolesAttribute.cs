using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksNet.Attributes
{
  public class AuthorizeRolesAttribute : AuthorizeAttribute
  {
    public AuthorizeRolesAttribute(params string[] roles) : base()
    {
      Roles = string.Join(",", roles);
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
      if (filterContext.HttpContext.User.Identity.IsAuthenticated)
      {
        filterContext.Result = new RedirectResult("/Admin/Error/AccessDenied");
      }
      else
      {
        base.HandleUnauthorizedRequest(filterContext);
      }
    }
  }
}