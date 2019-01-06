using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THAMGIA.Areas.PlayPage.Models;

namespace THAMGIA.Areas.PlayPage.Controllers
{
    public class PlayController : Controller
    {
        // GET: PlayPage/Play
        public ActionResult Index()
        {
            ViewData["Title"] = "AI LÀ TRIỆU PHÚ";
            if (Session["Username"] == null)
                return Redirect("/AccountPage/Account");
            else
                Session["HistoryID"] = HistoryM.UpdateHistory("0", Session["AccountID"].ToString(), 0, "0", 0); //Tạo history

            return View();
        }

        public JsonResult GetQuestionLevel(int Level)
        {
            QuestionM q = QuestionM.GetQuestionLevel(Level);

            Session["DetailID"] = HistoryM.UpdateHistoryDetail("0", Session["HistoryID"].ToString(), q.QuestionID.ToString(), Level.ToString()); //Insert historyDetail

            return Json(q, JsonRequestBehavior.AllowGet);
        }

        public int CheckAnswer(int QuestionID, int AnswerLevel)
        {
            HistoryM.UpdateHistoryDetail(Session["DetailID"].ToString(), Session["HistoryID"].ToString(), QuestionID.ToString(), AnswerLevel.ToString()); //update kết quả historyDetail
            return PlayM.CheckAnswer(QuestionID, AnswerLevel);
        }

        public string GetMoney(int QuestionLevel)
        {
            return PlayM.GetMoney(QuestionLevel);
        }

        public JsonResult GetListPrize()
        {
            return Json(PlayM.GetListPrize(), JsonRequestBehavior.AllowGet);
        }

        public string Support5050(int QuestionID)
        {
            int Result = Int32.Parse(PlayM.Support5050(QuestionID));
            Random r = new Random();
            int Answer1 = Result;
            int Answer2 = Result;

            while (Answer1 == Result || Answer2 == Result || Answer1 == Answer2)
            {
                Answer1 = r.Next(1, 5);
                Answer2 = r.Next(1, 5);
            }

            return Answer1 + ";" + Answer2;
        }

        public string SupportHKG(int QuestionID)
        {
            Random r = new Random();
            int Sum = 100;
            int Answer1 = r.Next(0, 100);
            int Answer2 = r.Next(0, Sum - Answer1);
            int Answer3 = r.Next(0, Sum - Answer1 - Answer2);
            int Answer4 = Sum - Answer1 - Answer2 - Answer3;

            return Answer1 + ";" + Answer2 + ";" + Answer3 + ";" + Answer4;
        }
        public void Stop(int Level, int Type)
        {
            HistoryM.UpdateHistory(Session["HistoryID"].ToString(), Session["AccountID"].ToString(), Level, "0", Type);
        }
    }
}