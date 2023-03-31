using AutoMapper;

using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Models.Avaliacoes;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.ModelMapper
{
    public class AvaliacaoModelMapper : Profile
    {
        public AvaliacaoModelMapper()
        {
            CreateMap<Avaliacao, AvaliacaoModel>().ReverseMap();
        }
    }
}
