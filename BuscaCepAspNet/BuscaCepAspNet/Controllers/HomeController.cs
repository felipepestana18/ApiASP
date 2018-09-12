using BuscaCepAspNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BuscaCepAspNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string CepBuscado = ""; //Cep a Ser Buscado.
            string url = "https://viacep.com.br/ws/" + CepBuscado + "/json/"; //Montagem da url

            WebRequest Requisicao = WebRequest.Create(url);
            WebResponse Resposta = Requisicao.GetResponse();

            StreamReader Leitor = new StreamReader(Resposta.GetResponseStream());
            string RespostaString = Leitor.ReadToEnd();
            Leitor.Close();

            ClasseCep ObjetoCep = JsonConvert.DeserializeObject<ClasseCep>(RespostaString);

            return View(ObjetoCep);
        }
    }
}