using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TAIKHOAN.Areas.AccountPage.Models
{
    public class AccountM
    {
        public int AccountID { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

        public static AccountM Login(string Username, string Password)
        {
            AccountM A = new AccountM();

            var data = new DataRequest{
                        Content = new {
                            Username = Username,
                            Password = Password
                        }
                      };

            var result = Function.CallAPI(Function.API_URL + "api/account/login", Function.API_Method.POST, data);
            if(result.GetValue("StatusCode").ToString() == "200")
            {
                A = result.GetValue("Detail").ToObject<AccountM>();
            }

            return A;
        }

        public static int Register(string Fullname, string Username, string Password)
        {
            int code = 0;
            var data = new DataRequest
            {
                Content = new
                {
                    Fullname = Fullname,
                    Username = Username,
                    Password = Password
                }
            };

            var result = Function.CallAPI(Function.API_URL + "api/account/register", Function.API_Method.POST, data);
            if (result.GetValue("StatusCode").ToString() == "200")
            {
                code = Int32.Parse(result.GetValue("Code").ToString());
            }

            return code;
        }
    }
}