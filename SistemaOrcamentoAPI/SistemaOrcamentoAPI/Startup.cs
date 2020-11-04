using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.IRepository;
using Repository.Repository;
using Domain.Interfaces.IServices;
using Services.Services;
using Application.Interfaces;
using Application;
using Adapter.Mapping;
using Data.Data.Repository;
using Application.Service;
using Security.Interfaces;
using Security;

namespace SistemaOrcamentoAPI
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
            services.AddControllers();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddHttpClient();
            services.AddCors();
            services.AddMvc();

            var connection = Configuration.GetConnectionString("Default");
            services.AddDbContext<ContextBase>(options => options.UseSqlServer(connection));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteServiceApplication, ClienteServiceApplication>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemServiceApplication, ItemServiceApplication>();


            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            services.AddScoped<IOrcamentoServiceApplication, OrcamentoServiceApplication>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioServiceApplication, UsuarioServiceApplication>();

            services.AddScoped<ICriptografia, Criptografia>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
