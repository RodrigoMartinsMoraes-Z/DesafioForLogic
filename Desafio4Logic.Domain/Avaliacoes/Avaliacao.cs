using Desafio4Logic.Domain.Clientes;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.Domain.Avaliacoes
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int Nota { get; set; }
        public DateTime? QuandoAvaliado { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
