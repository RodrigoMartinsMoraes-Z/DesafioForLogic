using AutoMapper;

using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Models.Clientes;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.ModelMapper
{
    public class ClienteModelMapper : Profile
    {
        public ClienteModelMapper()
        {
            CreateMap<Cliente, ClienteModel>().ReverseMap();
        }
    }
}
