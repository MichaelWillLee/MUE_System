using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUESystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override HttpNotFoundResult HttpNotFound(string statusDescription)
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;
            Response.Clear();
            Response.Redirect("~/Error");
            Response.End();
            return null;
        }
    }
}