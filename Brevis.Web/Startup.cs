using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Brevis.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brevis.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Inyeccion de dependencias que configura el IProgressCarreerTransformer correspondiente.
            services.Add(new ServiceDescriptor(typeof(IProgressCarreerTransformer), GetProgressCarreerTransformer()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }


        private IProgressCarreerTransformer GetProgressCarreerTransformer()
        {
            var rootPath = Directory.GetCurrentDirectory() + @"\..\ImporterImplementations";
            var files = Directory.GetFiles(rootPath);

            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                Type[] types = assembly.GetTypes();

                foreach (Type t in types)
                {
                    if (t.IsClass)
                    {
                        string typeName = t.AssemblyQualifiedName;
                        Type type = Type.GetType(typeName);

                        if (type.GetInterfaces().Contains(typeof(Brevis.Core.IProgressCarreerTransformer)))
                        {
                            Brevis.Core.IProgressCarreerTransformer obj = (IProgressCarreerTransformer)Activator.CreateInstance(type);

                            //Por ahora, devuelve la primer implementacion que encuentra. Esto cumple con el criterio de extensibilidad de la US1
                            //para la iteracion 2, podria buscar una implementacion segun algun criterio definido por el usuario.
                            return obj;
                        }
                    }
                }
            }

            throw new ArgumentException("Implementation not found");
        }
    }
}
