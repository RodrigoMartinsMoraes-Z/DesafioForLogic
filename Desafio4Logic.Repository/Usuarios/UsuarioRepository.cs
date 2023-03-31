using Desafio4Logic.Domain.Usuarios;
using Desafio4Logic.Interfaces.Context;
using Desafio4Logic.Interfaces.Repository;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desafio4Logic.Repository.Usuarios
{


    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ISQLContext _sqlContext;

        public UsuarioRepository(ISQLContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Usuario> SalvarUsuario(Usuario usuario)
        {
            await _sqlContext.Usuarios.AddAsync(usuario);
            await _sqlContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            return await _sqlContext.Usuarios.FindAsync(id);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _sqlContext.Usuarios.Update(usuario);
            await _sqlContext.SaveChangesAsync();
        }

    }
}
