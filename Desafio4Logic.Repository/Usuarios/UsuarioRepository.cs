using Desafio4Logic.Domain.Usuarios;
using Desafio4Logic.Interfaces.Context;
using Desafio4Logic.Interfaces.Repository;

using Microsoft.EntityFrameworkCore;

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
            _ = await _sqlContext.Usuarios.AddAsync(usuario);
            _ = await _sqlContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            return await _sqlContext.Usuarios.FindAsync(id);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _ = _sqlContext.Usuarios.Update(usuario);
            _ = await _sqlContext.SaveChangesAsync();
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string email)
        {
            return await _sqlContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
