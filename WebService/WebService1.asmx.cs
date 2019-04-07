using RestSharp;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public void EnviarMensagem(string assunto, string mensagem)
        {
            var client = new RestClient("http://localhost:50967/Service1.svc/mensagem");

            Mensagem msg = new Mensagem()
            {
                Assunto = assunto,
                Texto = mensagem
            };
            var json = new JavaScriptSerializer().Serialize(msg);
            var request = new RestRequest("", Method.POST);


            request.AddJsonBody(json);

            IRestResponse response = client.Execute(request);
        }
    }
}
