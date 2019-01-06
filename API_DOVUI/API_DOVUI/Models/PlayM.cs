using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_DOVUI.Models
{
    public class PlayM
    {
        public static int CheckAnswer(string QuestionID, string AnswerLevel)
        {
            SqlParameter Result = new SqlParameter();
            Result.DbType = DbType.Int32;
            Result.ParameterName = "@Result";
            Result.Direction = ParameterDirection.Output;

            SqlParameter[] pars = {
                new SqlParameter ("QuestionID", QuestionID),
                new SqlParameter ("AnswerLevel", AnswerLevel),
                Result
            };

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "CheckAnswer", pars);

            return Int32.Parse(Result.Value.ToString());
        }

        public static string GetMoney(string QuestionLevel)
        {
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.Text, "Select Money From PrizeMoney WHERE Level=" + QuestionLevel.ToString()).Tables[0].Rows[0]["Money"].ToString();
        }

        public static List<PrizeMoney> GetListPrize()
        {
            List<PrizeMoney> lst = new List<PrizeMoney>();
            DataSet ds =  SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.Text, "SELECT Level, Money FROM PrizeMoney ORDER BY Level DESC");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PrizeMoney p = new PrizeMoney();
                    p.Level = Int32.Parse(dr["Level"].ToString());
                    double money = Double.Parse(dr["Money"].ToString());
                    p.Money = money.ToString("#,###");
                    lst.Add(p);
                }
            }
            return lst;
        }

        public static string Support5050(string QuestionID)
        {
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.Text, "SELECT AnswerLevel FROM Answer WHERE QuestionID=" + QuestionID.ToString() + " AND ISNULL(IsResult, 0) = 1").Tables[0].Rows[0]["AnswerLevel"].ToString();
        }

    }
}