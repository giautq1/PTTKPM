using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace THAMGIA.Areas.PlayPage.Models
{
    public class PlayM
    {
        public static int CheckAnswer(int QuestionID, int AnswerLevel)
        {
            int check = 0;
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        QuestionID = QuestionID,
                        AnswerLevel = AnswerLevel
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/question/checkanswer", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    check = int.Parse(result.GetValue("Detail").ToString());
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return check;
        }

        public static string GetMoney(int QuestionLevel)
        {
            string money = "0";
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        QuestionLevel = QuestionLevel
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/question/getmoney", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    money = result.GetValue("Detail").ToString();
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return money;            
        }

        public static List<PrizeMoney> GetListPrize()
        {
            List<PrizeMoney> lst = new List<PrizeMoney>();
            try
            {
                var result = Function.CallAPI(Function.API_URL + "api/question/getlistprize", Function.API_Method.GET,null);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    lst = result.GetValue("Detail").ToObject<List<PrizeMoney>>();
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }
            return lst;
        }

        public static string Support5050(int QuestionID)
        {
            string money = "0";
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        QuestionID = QuestionID
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/question/support5050", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    money = result.GetValue("Detail").ToString();
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return money;
        }

    }
}