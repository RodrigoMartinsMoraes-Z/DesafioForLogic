using Desafio4Logic.Models.Avaliacoes;
using Desafio4Logic.Models.Usuarios;

using System;
using System.Collections.Generic;

namespace Desafio4Logic.Models.Clientes
{
    public class ClienteModel
    {
        private DateTime dataCadastro;


        public string Nome { get; set; }
        public string NomeContato { get; set; }
        public string CNPJ { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataCadastro { get => dataCadastro; private set => dataCadastro = DateTime.Today; }

        public virtual UsuarioModel Usuario { get; set; }
        public virtual ICollection<AvaliacaoModel> Avaliacoes { get; set; }
    }
}
