﻿using System.Net;

namespace Desafio4Logic.Models
{
    public class RespostaPadrao
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Resposta { get; set; }
    }
}
