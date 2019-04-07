using Interfaces;
using Shared.Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using WCF.OrderReader.Models;

namespace Teste
{
    
    //SINGLE -> INSTANCIA UNICA e Sigle-Thread
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, 
        InstanceContextMode = InstanceContextMode.Single, 
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class OrderInboundMessageHandlerService : IInboundMessageHandlerService
    {
        private static int increment = 0;
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<Shared.Contracts.Info> incomingOrderMessage)
        {
            Console.WriteLine("------------------------------------ mensagem recebida ---------------------------------------");

            var orderRequest = incomingOrderMessage.Body;

            WCF.OrderReader.Models.Info info = new WCF.OrderReader.Models.Info() { Id = increment++, Assunto = orderRequest.Assunto, Data = orderRequest.Data, Mensagem = orderRequest.Mensagem };

            using (var db = new Model1())
            {
                db.Info.Add(info);
                db.SaveChanges();
            }

            Console.WriteLine(orderRequest.Data);
            Console.WriteLine(orderRequest.Assunto);
            Console.WriteLine(orderRequest.Mensagem);
            Console.WriteLine();
        }
    }
}
