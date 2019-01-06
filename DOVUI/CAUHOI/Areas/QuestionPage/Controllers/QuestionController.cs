using CAUHOI.Areas.QuestionPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAUHOI.Areas.QuestionPage.Controllers
{
    public class QuestionController : Controller
    {
        // GET: QuestionPage/Question
        public ActionResult Index()
        {
            ViewData["Title"] = "AI LÀ TRIỆU PHÚ";

            if (Session["Username"] == null)
                return Redirect("/AccountPage/Account");
            else if (Session["Type"].ToString() != "1")
                return Redirect("/Home/Index");

            return View();
        }

        public ResData Create(string Content, int Level, string AnswerA, string AnswerB, string AnswerC, string AnswerD, int IsResult)
        {
            ResData res = new ResData();
            if (String.IsNullOrEmpty(Content))
            {
                res.ID = -1;
                res.Desc = "Nội dung câu hỏi không được để trống";
            }
            else if (String.IsNullOrEmpty(AnswerA) || String.IsNullOrEmpty(AnswerB) || String.IsNullOrEmpty(AnswerC) || String.IsNullOrEmpty(AnswerD))
            {
                res.ID = -2;
                res.Desc = "Đáp án không được để trống";
            }
            else
            {
                res.ID = QuestionM.Create(Content, Level, AnswerA, AnswerB, AnswerC, AnswerD, IsResult);
                if (res.ID == 1)
                    res.Desc = "Thêm mới thành công";
                else
                    res.Desc = "Thêm mới thất bại";
            }
                
            return res;
        }
    }
}