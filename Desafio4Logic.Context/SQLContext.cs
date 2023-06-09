﻿using Desafio4Logic.Context.Mapping;
using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Domain.Usuarios;
using Desafio4Logic.Interfaces.Context;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Desafio4Logic.Context
{
    public class SQLContext : DbContext, ISQLContext
    {
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Data Source=192.168.0.37,1433;Initial Catalog=Desafio4Logic;User ID=teste;Password=Teste123;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new AvaliacaoMapping());
            _ = modelBuilder.ApplyConfiguration(new ClienteMapping());
            _ = modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
