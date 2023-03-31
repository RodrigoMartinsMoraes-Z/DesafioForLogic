using Desafio4Logic.Context.Mapping;
using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Domain.Usuarios;

using Microsoft.EntityFrameworkCore;

namespace Desafio4Logic.Context
{
    public class SQLContext : DbContext
    {
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.0.37,1433;Initial Catalog=Desafio4Logic;User ID=teste;Password=Teste123;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvaliacaoMapping());
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
