using AutoMapper;

using Desafio4Logic.Context;
using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Interfaces.Context;
using Desafio4Logic.Interfaces.Repository;
using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.ModelMapper;
using Desafio4Logic.Repository.Avaliacoes;
using Desafio4Logic.Repository.Clientes;
using Desafio4Logic.Repository.Usuarios;
using Desafio4Logic.Services;
using Desafio4Logic.Services.Validation;

using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio4Logic.Api.Cliente
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Registro do banco sql
            services.AddDbContext<SQLContext>();

            //Registro automapper
            services.AddAutoMapper(typeof(AvaliacaoModelMapper));
            services.AddAutoMapper(typeof(ClienteModelMapper));
            services.AddAutoMapper(typeof(UsuarioModelMapper));

            //Registro de interfaces
            services.AddScoped<ISQLContext, SQLContext>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente API", Version = "v1" });
            });

            services.AddControllers();

            //registro do validator
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddTransient<IValidator<Domain.Usuarios.Usuario>, UsuarioValidator>();
            services.AddTransient<IValidator<Domain.Clientes.Cliente>, ClienteValidator>();
            services.AddTransient<IValidator<Avaliacao>, AvaliacaoValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
