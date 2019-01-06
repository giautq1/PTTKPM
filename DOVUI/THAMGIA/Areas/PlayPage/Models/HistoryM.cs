using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace THAMGIA.Areas.PlayPage.Models
{
    public class HistoryM
    {
        public static int UpdateHistory(string HistoryID, string AccountID, int Level, string Total, int Type)
        {
            int isUpdate = 0;
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        HistoryID = HistoryID,
                        AccountID = AccountID,
                        Level = Level,
                        Total = Total,
                        Type = Type
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/history/updatehistory", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    isUpdate = int.Parse(result.GetValue("Detail").ToString());
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return isUpdate;
        }

        public static int UpdateHistoryDetail(string DetailID, string HistoryID, string QuestionID, string AnswerLevel)
        {
            int isUpdate = 0;
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        DetailID = DetailID,
                        HistoryID = HistoryID,
                        QuestionID = QuestionID,
                        AnswerLevel = AnswerLevel
                    }
                };

                var result = Function.CallAPI(Function.API_URL + "api/history/updatehistorydetail", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    isUpdate = int.Parse(result.GetValue("Detail").ToString());
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return isUpdate;
        }
    }
}