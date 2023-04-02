using AutoMapper;

using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Models.Avaliacoes;

namespace Desafio4Logic.ModelMapper
{
    public class AvaliacaoModelMapper : Profile
    {
        public AvaliacaoModelMapper()
        {
            _ = CreateMap<Avaliacao, AvaliacaoModel>().ReverseMap();
        }
    }
}
