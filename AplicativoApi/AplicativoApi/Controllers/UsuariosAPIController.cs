using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plugin.Controllers
{
    public class UsuariosAPIController : ApiController
    {
        private CadastrosContext context = new CadastrosContext();
        public string Get()
        {
            var Usuarios = context.Usuarios.ToList();

            return JsonConvert.SerializeObject(Usuarios);
        }
    }
}
