using EnviarMsgWCF.Model;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EnviarMsgWCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        //[WebGet(UriTemplate = "mensagem", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "mensagem")]
        void EnviarMsg(Mensagem mensagem);

        // TODO: Adicione suas operações de serviço aqui
    }
}
