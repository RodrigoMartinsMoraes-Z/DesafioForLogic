using Desafio4Logic.Models.Avaliacoes;
using Desafio4Logic.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        Task<RespostaPadrao> BuscarAvaliacoesDoCliente(int clienteId);
        Task<RespostaPadrao> BuscarAvaliacoesDoMes(int mes, int ano);
        Task<RespostaPadrao> CadastrarAvaliação(AvaliacaoModel avaliacaoModel, int idCliente);
    }
}
