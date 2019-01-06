using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LICHSU.Areas.HistoryPage.Models
{
    public class HistoryM
    {
        public int STT { get; set; }
        public int HistoryID { get; set; }
        public int AccountID { get; set; }
        public int Level { get; set; }
        public string Total { get; set; }
        public string Createdate { get; set; }
        public string Finishdate { get; set; }

        public static List<HistoryM> GetListHistory(string AccountID)
        {           
            List<HistoryM> lst = new List<HistoryM>();
            try
            {
                var data = new DataRequest
                {
                    Content = new
                    {
                        AccountID = AccountID
                    }
                };
                var result = Function.CallAPI(Function.API_URL + "api/history/getlisthistory", Function.API_Method.POST, data);
                if (result.GetValue("StatusCode").ToString() == "200")
                {
                    lst = result.GetValue("Detail").ToObject<List<HistoryM>>();
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }
            return lst;
        }
    }
}