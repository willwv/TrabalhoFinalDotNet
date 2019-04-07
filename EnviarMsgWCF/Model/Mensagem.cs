using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EnviarMsgWCF.Model
{
    [DataContract]
    public class Mensagem
    {
        [DataMember]
        public string Texto { get; set; }
        [DataMember]
        public string Assunto { get; set; }
    }
}