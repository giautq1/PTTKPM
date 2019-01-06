using LICHSU.Areas.HistoryPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LICHSU.Areas.HistoryPage.Controllers
{
    public class HistoryController : Controller
    {
        // GET: HistoryPage/History
        public ActionResult Index()
        {
            ViewData["Title"] = "AI LÀ TRIỆU PHÚ";
            if (Session["Username"] == null)
                return Redirect("/AccountPage/Account");
            else
            {
                List<HistoryM> lst = HistoryM.GetListHistory(Session["AccountID"].ToString());
                if (lst.Count > 0)
                {
                    ViewData["List"] = true;
                    ViewData["gird"] = lst;
                }
                else
                {
                    ViewData["List"] = false;
                    ViewData["gird"] = "";
                }
            }

            return View();
        }
    }
}