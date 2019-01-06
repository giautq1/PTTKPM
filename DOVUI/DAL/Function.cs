using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Web.Configuration;

namespace DAL
{
    public class Function
    {

        /*Chuyển Tiếng việt sang Tieng Viet*/
        public static string RemoveUnicode(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /* Call API */
        public static JObject CallAPI(string url, API_Method method, object request)
        {
            string json = "";
            JObject data = null;
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);


                Request.Method = method.ToString();
                Request.KeepAlive = false;
                Request.ContentType = "application/json; charset=UTF-8";
                //Request.Headers.Add(string.Format("Authorization: key={0}",""));                

                if (method == API_Method.POST)
                {
                    Byte[] byteArray = Encoding.UTF8.GetBytes(new JavaScriptSerializer().Serialize(request));
                    Request.ContentLength = byteArray.Length;
                    Stream dataStream = Request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                }
                /*Kiểm tra kết quả trả về */
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    string description = "Unauthorized - need new token";
                    // FileLog.WriteLogCallAPI(description, url);

                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    string description = "Response from web service isn't OK";
                    //FileLog.WriteLogCallAPI(description, url);
                }
                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                json = Reader.ReadToEnd();
                //  FileLog.WriteLogCallAPI(json, url);
                Reader.Close();
                data = JObject.Parse(json);
                
            }
            catch (Exception ex)
            {
                string description = "Lỗi try catch";
                // FileLog.WriteLogCallAPI(description + ":" + ex.Message, url);
            }
            return data;
        }

        /* Check Response statusCode */
        private bool CheckstatusCode<T>(JsonResponse<T> dataresponse) where T : class
        {
            bool flag = false;
            if (dataresponse != null)
            {
                if (dataresponse.resCode == 200)
                    flag = true;
            }
            return flag;
        }



        public enum API_Method
        {
            GET = 1,
            POST = 2
        }

        public static string API_URL = WebConfigurationManager.AppSettings["API_URL"];

    }

    public class JsonResponse<T>
    {
        public string resdata { get; set; }
        public int resCode { get; set; }
        public string Message { get; set; }

    }

    #region----------------------- Private Class ---------------------------------
    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }

    public class DataRequest
    {
        public Object Content;
    }

    #endregion
}
