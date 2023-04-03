using Desafio4Logic.Models.Avaliacoes;
using Desafio4Logic.Models.Usuarios;

using System;
using System.Collections.Generic;

namespace Desafio4Logic.Models.Clientes
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeContato { get; set; }
        public string CNPJ { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataCadastro { get;  }

        public virtual UsuarioModel Usuario { get; set; }
        public virtual ICollection<AvaliacaoModel> Avaliacoes { get; set; }
    }
}
