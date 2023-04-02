using AutoMapper;

using Desafio4Logic.Domain.Usuarios;
using Desafio4Logic.Models.Usuarios;

namespace Desafio4Logic.ModelMapper
{
    public class UsuarioModelMapper : Profile
    {
        public UsuarioModelMapper()
        {
            _ = CreateMap<Usuario, UsuarioModel>().ReverseMap();
        }
    }
}
