using EnviarMsgWCF.Model;
using System;
using System.Configuration;
using System.Messaging;
using System.Transactions;

namespace EnviarMsgWCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service1 : IService1
    {
        public void EnviarMsg(Mensagem mensagem)
        {
            var info = new Info { Assunto = mensagem.Assunto, Mensagem = mensagem.Texto, Data = DateTime.Now };

            // Pegando o caminho da Fila no App.Config -> AppSettings
            using (var queue = new MessageQueue(ConfigurationManager.AppSettings["MessageQueuePath"]))
            {
                // Criando uma msg
                var msg = new System.Messaging.Message { Body = info };

                // Criando uma transação
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    queue.Send(msg, MessageQueueTransactionType.Automatic); // send the message
                    ts.Complete();
                }
            }
        }
    }
}
