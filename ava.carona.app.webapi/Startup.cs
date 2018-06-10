using AutoMapper;
using ava.carona.app.business;
using ava.carona.app.domains;
using ava.carona.app.facade;
using ava.carona.app.repositories;
using ava.carona.app.webapi.dto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net;

namespace ava.carona.app.webapi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddScoped<ICaronaRepositorio, CaronaRepositorioEF>();
            services.AddScoped<ICaronaNegocio, CaronaNegocio>();
            services.AddScoped<IColaboradorRepositorio, ColaboradorRepositorioEF>();
            services.AddScoped<IColaboradorNegocio, ColaboradorNegocio>();
            services.AddScoped<IFachada, Fachada>();
            services.AddScoped<DbContext, AppContext>();

            Mapper.Initialize(config =>
           {
               config.CreateMap<ColaboradorDTO, Colaborador>();
               config.CreateMap<Colaborador, ColaboradorDTO>()
                .ForSourceMember(src => src.CreatedAt, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore()); 
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseExceptionHandler(options => {
            //    options.Run(
            //    async context =>
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        //context.Response.ContentType = "text/html";
            //        var ex = context.Features.Get<IExceptionHandlerFeature>();
            //        if (ex != null)
            //        {
            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Error)).ConfigureAwait(false);
            //        }
            //    });
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseStatusCodePages();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
