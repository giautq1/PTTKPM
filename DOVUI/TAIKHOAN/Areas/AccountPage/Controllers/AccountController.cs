using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TAIKHOAN.Areas.AccountPage.Models;

namespace TAIKHOAN.Areas.AccountPage.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "AI LÀ TRIỆU PHÚ";
            if (Session["Username"] != null)
                ViewData["Username"] = Session["Username"];

            return View();
        }

        public ActionResult Register()
        {
            ViewData["Title"] = "AI LÀ TRIỆU PHÚ";
            return View();
        }


        public int CheckLogin(string Username, string Password)
        {
            int Result = 0;

            //Check db           
            Password = MD5Hash(Password);
            AccountM A = new AccountM();
            A = AccountM.Login(Username, Password);

            if (!string.IsNullOrEmpty(A.Username))
            {
                Session["AccountID"] = A.AccountID;
                Session["Fullname"] = A.Fullname;
                Session["Username"] = A.Username;
                Session["Type"] = A.Type;
                Result = 1;
            }

            return Result;
        }

        public void RemoveSession(string Username)
        {
            Session["Username"] = null;
        }

        public int CreateAccount(string Fullname, string Username, string Password)
        {
            if (string.IsNullOrEmpty(Fullname))
                return 3;
            else if (string.IsNullOrEmpty(Username))
                return 4;
            else if (string.IsNullOrEmpty(Password))
                return 5;

            Password = MD5Hash(Password);

            return AccountM.Register(Fullname, Username, Password);
        }

        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}