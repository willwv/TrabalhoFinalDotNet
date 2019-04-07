using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Shared.Contracts;
using System.Threading.Tasks;

namespace WebApiCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviarMensagemController : ControllerBase
    {
        [HttpPost]
        public async void Post([FromBody] Mensagem mensagem)
        {
            var client = new RestClient("http://localhost:50967/Service1.svc/mensagem");
            var json = JsonConvert.SerializeObject(mensagem);

            var request = new RestRequest("", Method.POST);


            request.AddJsonBody(json);

            var response = await client.ExecuteAsync(request);
        }
    }
}
