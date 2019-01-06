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

            SqlParameter[] pars = {
                new SqlParameter ("AccountID", AccountID)
            };

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "GetListHistory", pars);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HistoryM his = new HistoryM();
                    his.STT = Int32.Parse(dr["STT"].ToString());
                    his.HistoryID = Int32.Parse(dr["HistoryID"].ToString());
                    his.AccountID = Int32.Parse(dr["AccountID"].ToString());
                    his.Level = Int32.Parse(dr["Level"].ToString());
                    double total = Double.Parse(dr["Total"].ToString());
                    if (total > 0)
                        his.Total = total.ToString("#,#");
                    else
                        his.Total = "0";

                    his.Createdate = dr["Createdate"].ToString();
                    his.Finishdate = dr["Finishdate"].ToString();

                    lst.Add(his);
                }
            }

            return lst;
        }
    }
}