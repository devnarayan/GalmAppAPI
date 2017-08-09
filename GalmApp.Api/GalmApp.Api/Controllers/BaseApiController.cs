using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GalmApp.Api.Controllers
{
    public class BaseApiController: ApiController
    {

    }
    public class ResponseModel
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }
    }
}