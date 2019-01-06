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
    public class AccountController : ApiController
    {
        // POST api/values
        [Route("api/account/login")]
        public HttpResponseMessage Login(ReqData req)
        {            
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string Username = Content.Username.ToString();
                string Password = Content.Password.ToString();

                AccountM AM = AccountM.Login(Username, Password);
                
                if (AM.AccountID > 0)
                {
                    res.Code = 1;
                    res.Message = "Đăng nhập thành công";
                    res.Detail = AM;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    res.Code = -1;
                    res.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                    res.Detail = AM;
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

        [Route("api/account/register")]
        public HttpResponseMessage Register(ReqData req)
        {
            ResData res = new ResData();
            try
            {
                var Content = JsonConvert.DeserializeObject<dynamic>(req.Content.ToString());
                string Fullname = Content["Fullname"].ToString();
                string Username = Content["Username"].ToString();
                string Password = Content["Password"].ToString();

                int RegisRes = AccountM.Register(Fullname, Username, Password);

                if (RegisRes == 1)
                {
                    res.Code = 1;
                    res.Message = "Đăng ký thành công";
                    res.Detail = req.Content;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else if (RegisRes == 2)
                {
                    res.Code = 2;
                    res.Message = "Tên đăng nhập đã tồn tại";
                    res.Detail = req.Content;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else if (RegisRes == 3)
                {
                    res.Code = 3;
                    res.Message = "Họ và tên không được để trống";
                    res.Detail = req.Content;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else if (RegisRes == 4)
                {
                    res.Code = 4;
                    res.Message = "Tên đăng nhập không được để trống";
                    res.Detail = req.Content;
                    res.StatusCode = HttpStatusCode.OK;
                }
                else if (RegisRes == 5)
                {
                    res.Code = 5;
                    res.Message = "Mật khẩu không được để trống";
                    res.Detail = req.Content;
                    res.StatusCode = HttpStatusCode.OK;
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
