using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Domain.Usuarios;

using System;
using System.Collections.Generic;

namespace Desafio4Logic.Domain.Clientes
{
    public class Cliente
    {
        private DateTime dataCadastro;

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string NomeContato { get; set; }
        public string CNPJ { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataCadastro { get => dataCadastro; private set => dataCadastro = DateTime.Today; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
