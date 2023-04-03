using Desafio4Logic.Context;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Avaliacoes;
using Desafio4Logic.Services;

using Moq;

using System;
using System.Threading.Tasks;

using Xunit;

namespace Desafio4Logic.TestexUnit.Services
{
    public class AvaliacaoTeste
    {
        [Fact]
        public async Task CadastrarAvaliacaoComSucesso()
        {
            var avaliacaoServiceMock = new Mock<AvaliacaoService>();

            AvaliacaoModel model = ObterAvaliacaoModel();
            var resposta = RespostaCadastro();
            avaliacaoServiceMock.Setup(a => a.CadastrarAvaliação(model, 1)).Returns(resposta);

            var result = await avaliacaoServiceMock.Object.CadastrarAvaliação(model, 1);

            Assert.Equal(await RespostaCadastro(), result);
        }

        private AvaliacaoModel ObterAvaliacaoModel()
        {
            return new AvaliacaoModel()
            {
                Cliente = new Models.Clientes.ClienteModel { CNPJ = "11111111111", Nome = "cliente teste", NomeContato = "contato cliente" },
                Nota = 10
            };
        }

        private Task<RespostaPadrao> RespostaCadastro()
        {
            return Task.FromResult(
                new RespostaPadrao
                {
                    Message = "Avaliação cadastrada com sucesso.",
                    Status = System.Net.HttpStatusCode.OK
                }
            );
        }
    }
}
