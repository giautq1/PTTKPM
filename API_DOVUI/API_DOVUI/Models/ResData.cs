using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace API_DOVUI.Models
{
    public class ResData
    {
        public HttpStatusCode StatusCode { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public Object Detail { get; set; }

        public ResData()
        {
            this.StatusCode = HttpStatusCode.NotImplemented;
            this.Code = -100;
            this.Message = "";
            this.Detail = "";
        }
    }    
}