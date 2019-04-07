﻿using System;
using System.Runtime.Serialization;

namespace WCFEnviarMensagemParaBanco.Model
{
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