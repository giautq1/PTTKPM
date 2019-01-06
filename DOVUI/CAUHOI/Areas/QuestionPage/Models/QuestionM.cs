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
            DataSet ds = new DataSet();
            SqlParameter Result = new SqlParameter();
            Result.DbType = DbType.Int32;
            Result.ParameterName = "@Result";
            Result.Direction = ParameterDirection.Output;

            SqlParameter[] pars = {
                new SqlParameter ("Content", Content),
                new SqlParameter ("Level", Level),
                new SqlParameter ("AnswerA", AnswerA),
                new SqlParameter ("AnswerB", AnswerB),
                new SqlParameter ("AnswerC", AnswerC),
                new SqlParameter ("AnswerD", AnswerD),
                new SqlParameter ("IsResult", IsResult),
                Result
            };

            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "CreateQuestion", pars);

            return Int32.Parse(Result.Value.ToString());
        }
    }

    public class ResData
    {
        public int ID { get; set; }
        public string Desc { get; set; }
    }
}