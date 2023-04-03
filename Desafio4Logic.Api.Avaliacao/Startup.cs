using Desafio4Logic.Context;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Desafio4Logic.Api.Avaliacao
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
            _ = services.AddDbContext<SQLContext>();

            //Registro automapper
            _ = services.AddAutoMapper(typeof(AvaliacaoModelMapper));
            _ = services.AddAutoMapper(typeof(ClienteModelMapper));
            _ = services.AddAutoMapper(typeof(UsuarioModelMapper));

            //Registro de interfaces
            _ = services.AddScoped<ISQLContext, SQLContext>();
            _ = services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            _ = services.AddScoped<IClienteRepository, ClienteRepository>();
            _ = services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            _ = services.AddScoped<ILoginService, LoginService>();
            _ = services.AddScoped<IUsuarioService, UsuarioService>();
            _ = services.AddScoped<IAvaliacaoService, AvaliacaoService>();

            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Avaliacao API", Version = "v1" });
            });

            _ = services.AddControllers();

            //registro do validator
            _ = services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            _ = services.AddTransient<IValidator<Domain.Usuarios.Usuario>, UsuarioValidator>();
            _ = services.AddTransient<IValidator<Cliente>, ClienteValidator>();
            _ = services.AddTransient<IValidator<Domain.Avaliacoes.Avaliacao>, AvaliacaoValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avaliacao API V1");
            });

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
