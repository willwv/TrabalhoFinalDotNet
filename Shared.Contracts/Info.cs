using System;
using System.Runtime.Serialization;

namespace Shared.Contracts
{
    /// <summary>
    /// Classe que será enviada para o MSMQ
    /// </summary>
    [DataContract]
    public class Info
    {
        [DataMember(IsRequired = true)]
        public DateTime Data { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Assunto { get; set; }

        [DataMember(IsRequired = true)]
        public string Mensagem { get; set; }
    }
}
