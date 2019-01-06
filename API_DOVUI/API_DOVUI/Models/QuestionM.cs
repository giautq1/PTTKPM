using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_DOVUI.Models
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
                SqlParameter[] pars = {
                new SqlParameter ("Level", Level)
            };

                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "GetQuestionLevel", pars);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    q.QuestionID = int.Parse(ds.Tables[0].Rows[0]["QuestionID"].ToString());
                    q.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                    q.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                    q.AnswerA = ds.Tables[0].Rows[0]["AnswerA"].ToString();
                    q.AnswerB = ds.Tables[0].Rows[0]["AnswerB"].ToString();
                    q.AnswerC = ds.Tables[0].Rows[0]["AnswerC"].ToString();
                    q.AnswerD = ds.Tables[0].Rows[0]["AnswerD"].ToString();
                    q.IsResult = int.Parse(ds.Tables[0].Rows[0]["IsResult"].ToString());
                }
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            return q;
        }

        public static int Create(string Content, string Level, string AnswerA, string AnswerB, string AnswerC, string AnswerD, string IsResult)
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
}