using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MUESystem.Web.MUEAuthorize;

namespace MUESystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpAuthorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}