using RestFullKitap.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestFullKitap.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage GetTeste()
        {
            var serviceBuscaDeCategorias = new BuscarCategoriasService();
            var categorias = serviceBuscaDeCategorias.PesquisarCategoriasTeste();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categorias);
            return response;
        }
    }
}
