using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_DOVUI.Models
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
        public static int UpdateHistory(string HistoryID, string AccountID, int Level, string Total, int Type)
        {
            SqlParameter HistoryIDOUT = new SqlParameter();
            HistoryIDOUT.DbType = DbType.Int32;
            HistoryIDOUT.ParameterName = "@HistoryIDOUT";
            HistoryIDOUT.Direction = ParameterDirection.Output;

            SqlParameter[] pars = {
                new SqlParameter ("HistoryID", HistoryID),
                new SqlParameter ("AccountID", AccountID),
                new SqlParameter ("Level", Level),
                new SqlParameter ("Total", Total),
                new SqlParameter ("Type", Type),
                HistoryIDOUT
            };

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "UpdateHistory", pars);

            return Int32.Parse(HistoryIDOUT.Value.ToString());
        }

        public static int UpdateHistoryDetail(string DetailID, string HistoryID, string QuestionID, string AnswerLevel)
        {
            SqlParameter DetailIDOUT = new SqlParameter();
            DetailIDOUT.DbType = DbType.Int32;
            DetailIDOUT.ParameterName = "@DetailIDOUT";
            DetailIDOUT.Direction = ParameterDirection.Output;

            SqlParameter[] pars = {
                new SqlParameter ("DetailID", DetailID),
                new SqlParameter ("HistoryID", HistoryID),
                new SqlParameter ("QuestionID", QuestionID),
                new SqlParameter ("AnswerLevel", AnswerLevel),
                DetailIDOUT
            };

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "UpdateHistoryDetail", pars);

            return Int32.Parse(DetailIDOUT.Value.ToString());
        }

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