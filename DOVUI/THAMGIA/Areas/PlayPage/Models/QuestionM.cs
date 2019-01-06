using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace THAMGIA.Areas.PlayPage.Models
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

        public static QuestionM GetQuestionLevel(int Level)
        {
            QuestionM q = new QuestionM();
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        Level = Level
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/question/getquestionlevel", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    q = result.GetValue("Detail").ToObject<QuestionM>();
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return q;
        }


    }
}