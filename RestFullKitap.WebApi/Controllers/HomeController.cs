﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFullKitap.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage GetTeste()
        {
             HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Holla michel");
             return response;
        }
    }
}