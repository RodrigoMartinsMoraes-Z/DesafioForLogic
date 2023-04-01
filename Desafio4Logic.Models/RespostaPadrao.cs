using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Desafio4Logic.Models
{
    public class RespostaPadrao
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Resposta { get; set; }
    }
}
