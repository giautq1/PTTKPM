using API_DOVUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DOVUI.Controllers
{
    public class HistoryController : ApiController
    {
        // POST api/values
        [Route("api/history/getlisthistory")]
        [HttpPost]
        public HttpResponseMessage GetListHistory(ReqData req)
        {            
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string AccountID = Content.AccountID.ToString();

                List<HistoryM> history = HistoryM.GetListHistory(AccountID);
                
                if (history != null && history.Count > 0)
                {
                    res.Code = 1;
                    res.Message = "Thành công";
                    res.Detail = history;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    res.Code = -1;
                    res.Message = "Thông thành công";
                    res.Detail = history;
                    res.StatusCode = HttpStatusCode.NonAuthoritativeInformation;
                }                         
            }
            catch(Exception ex)
            {
                res.Code = -99;
                res.Message = ex.Message;                
                res.StatusCode = HttpStatusCode.BadRequest;                
            }

            return Request.CreateResponse(res.StatusCode, res);
        }

        [Route("api/history/updatehistory")]
        [HttpPost]
        public HttpResponseMessage UpdateHistory(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string HistoryID = Content.HistoryID.ToString();
                string AccountID = Content.AccountID.ToString();
                int Level = int.Parse(Content.Level.ToString());
                string Total = Content.Total.ToString();
                int Type = int.Parse(Content.Type.ToString());

                int historyM = HistoryM.UpdateHistory(HistoryID, AccountID, Level, Total, Type);

                if (historyM > 0)
                {
                    res.Code = 1;
                    res.Message = "Cập nhật history thành công";
                    res.Detail = historyM;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    res.Code = -1;
                    res.Message = "Cập nhật history không thành công";
                    res.Detail = historyM;
                    res.StatusCode = HttpStatusCode.NonAuthoritativeInformation;
                }
            }
            catch (Exception ex)
            {
                res.Code = -99;
                res.Message = ex.Message;
                res.StatusCode = HttpStatusCode.BadRequest;
            }

            return Request.CreateResponse(res.StatusCode, res);
        }

        [Route("api/history/updatehistorydetail")]
        [HttpPost]
        public HttpResponseMessage UpdateHistoryDetail(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string DetailID = Content.DetailID.ToString();
                string HistoryID = Content.HistoryID.ToString();
                string QuestionID = Content.QuestionID.ToString();
                string AnswerLevel = Content.AnswerLevel.ToString();

                int historyM = HistoryM.UpdateHistoryDetail(DetailID, HistoryID, QuestionID, AnswerLevel);

                if (historyM > 0)
                {
                    res.Code = 1;
                    res.Message = "Cập nhật history detail thành công";
                    res.Detail = historyM;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    res.Code = -1;
                    res.Message = "Cập nhật history không detail thành công";
                    res.Detail = historyM;
                    res.StatusCode = HttpStatusCode.NonAuthoritativeInformation;
                }
            }
            catch (Exception ex)
            {
                res.Code = -99;
                res.Message = ex.Message;
                res.StatusCode = HttpStatusCode.BadRequest;
            }

            return Request.CreateResponse(res.StatusCode, res);
        }

    }
}
