using Shared.Contracts;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace Interfaces
{
    [ServiceKnownType(typeof(Info))]
    [ServiceContract]
    public interface IInboundMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessIncomingMessage(MsmqMessage<Info> incomingOrderMessage);
    }
}
