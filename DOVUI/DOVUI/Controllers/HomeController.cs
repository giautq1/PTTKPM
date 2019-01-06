using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOVUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "AI LÀ TRIỆU PHÚ";
            if (Session["Username"] != null)
                ViewData["Username"] = Session["Username"];

            return View();
        }
    }
}