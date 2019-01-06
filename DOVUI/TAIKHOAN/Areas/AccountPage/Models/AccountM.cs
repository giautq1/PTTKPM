using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TAIKHOAN.Areas.AccountPage.Models
{
    public class AccountM
    {
        public int AccountID { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

        public static AccountM Login(string Username, string Password)
        {
            AccountM A = new AccountM();

            DataSet ds = new DataSet();
            SqlParameter[] pars = {
                new SqlParameter ("Username", Username),
                new SqlParameter ("Password", Password),
            };

            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "Logging", pars);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                A.AccountID = int.Parse(ds.Tables[0].Rows[0]["AccountID"].ToString());
                A.Fullname = ds.Tables[0].Rows[0]["Fullname"].ToString();
                A.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                A.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                A.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
            }

            return A;
        }

        public static int Register(string Fullname, string Username, string Password)
        {
            DataSet ds = new DataSet();
            SqlParameter Result = new SqlParameter();
            Result.DbType = DbType.Int32;
            Result.ParameterName = "@Result";
            Result.Direction = ParameterDirection.Output;

            SqlParameter[] pars = {
                new SqlParameter ("Fullname", Fullname),
                new SqlParameter ("Username", Username),
                new SqlParameter ("Password", Password),
                Result
            };

            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, "Register", pars);

            return Int32.Parse(Result.Value.ToString());
        }
    }
}