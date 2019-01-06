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
    }
}