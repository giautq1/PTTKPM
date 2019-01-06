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
    public class QuestionController : ApiController
    {
       
        [Route("api/question/getquestionlevel")]
        [HttpPost]
        public HttpResponseMessage GetQuestionLevel(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                int Level = int.Parse(Content.Level.ToString());

                QuestionM QM = QuestionM.GetQuestionLevel(Level);

                if (QM.QuestionID > 0)
                {
                    res.Code = 1;
                    res.Message = "Lấy dữ liệu OK";
                    res.Detail = QM;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    res.Code = -1;
                    res.Message = "Không có dữ liệu";
                    res.Detail = QM;
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

        [Route("api/question/getlistprize")]        
        public HttpResponseMessage GetListPrize()
        {
            ResData res = new ResData();
            try
            {
                List<PrizeMoney> lst = PlayM.GetListPrize();

                if (lst != null && lst.Count() > 0)
                {
                    res.Code = 1;
                    res.Message = "Lấy dữ liệu OK";
                    res.Detail = lst;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    res.Code = -1;
                    res.Message = "Không có dữ liệu";
                    res.Detail = lst;
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

        [Route("api/question/getmoney")]
        [HttpPost]
        public HttpResponseMessage GetMoney(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string QuestionLevel = Content.QuestionLevel.ToString();

                string money = PlayM.GetMoney(QuestionLevel);

                res.Code = 1;
                res.Message = "Thành công";
                res.Detail = money;
                res.StatusCode = HttpStatusCode.OK;
                
            }
            catch (Exception ex)
            {
                res.Code = -99;
                res.Message = ex.Message;
                res.StatusCode = HttpStatusCode.BadRequest;
            }

            return Request.CreateResponse(res.StatusCode, res);
        }

        [Route("api/question/support5050")]
        [HttpPost]
        public HttpResponseMessage Support5050(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string QuestionID = Content.QuestionID.ToString();

                string support = PlayM.Support5050(QuestionID);

                res.Code = 1;
                res.Message = "Thành công";
                res.Detail = support;
                res.StatusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                res.Code = -99;
                res.Message = ex.Message;
                res.StatusCode = HttpStatusCode.BadRequest;
            }

            return Request.CreateResponse(res.StatusCode, res);
        }

        [Route("api/question/checkanswer")]
        [HttpPost]
        public HttpResponseMessage CheckAnswer(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string QuestionID = Content.QuestionID.ToString();
                string AnswerLevel = Content.AnswerLevel.ToString();

                int check = PlayM.CheckAnswer(QuestionID, AnswerLevel);

                res.Code = 1;
                res.Message = "Thành công";
                res.Detail = check;
                res.StatusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                res.Code = -99;
                res.Message = ex.Message;
                res.StatusCode = HttpStatusCode.BadRequest;
            }

            return Request.CreateResponse(res.StatusCode, res);
        }

        [Route("api/question/create")]
        [HttpPost]
        public HttpResponseMessage Create(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                //string Content, int Level, string AnswerA, string AnswerB, string AnswerC, string AnswerD, int IsResult
                string Content = data.Content.ToString();
                string Level = data.Level.ToString();
                string AnswerA = data.AnswerA.ToString();
                string AnswerB = data.AnswerB.ToString();
                string AnswerC = data.AnswerC.ToString();
                string AnswerD = data.AnswerD.ToString();
                string IsResult = data.IsResult.ToString();

                int check = QuestionM.Create(Content, Level, AnswerA, AnswerB, AnswerC, AnswerD, IsResult);

                res.Code = 1;
                res.Message = "Thành công";
                res.Detail = check;
                res.StatusCode = HttpStatusCode.OK;

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
