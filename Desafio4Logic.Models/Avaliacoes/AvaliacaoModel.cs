
using Desafio4Logic.Models.Clientes;

using System;

namespace Desafio4Logic.Models.Avaliacoes
{
    public class AvaliacaoModel
    {
        public int Nota { get; set; }
        public DateTime? QuandoAvaliado { get; set; }

        public virtual ClienteModel Cliente { get; set; }
    }
}
