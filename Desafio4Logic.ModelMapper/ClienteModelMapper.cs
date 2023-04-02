using AutoMapper;

using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Models.Clientes;

namespace Desafio4Logic.ModelMapper
{
    public class ClienteModelMapper : Profile
    {
        public ClienteModelMapper()
        {
            _ = CreateMap<Cliente, ClienteModel>().ReverseMap();
        }
    }
}
