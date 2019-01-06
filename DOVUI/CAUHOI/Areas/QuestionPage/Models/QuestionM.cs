using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CAUHOI.Areas.QuestionPage.Models
{
    public class QuestionM
    {
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public int Level { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public int IsResult { get; set; }

        public static int Create(string Content, int Level, string AnswerA, string AnswerB, string AnswerC, string AnswerD, int IsResult)
        {
            int check = 0;
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        Content = Content,
                        Level = Level,
                        AnswerA = AnswerA,
                        AnswerB = AnswerB,
                        AnswerC = AnswerC,
                        AnswerD = AnswerD,
                        IsResult = IsResult
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/question/create", Function.API_Method.POST, data);
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
    }

    public class ResData
    {
        public int ID { get; set; }
        public string Desc { get; set; }
    }
}