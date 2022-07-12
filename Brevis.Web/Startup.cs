using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Brevis.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Brevis.Web.ServiceResolver;

namespace Brevis.Web
{
    public class Startup
    {
        private readonly Discover _discover;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _discover = new Discover();
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

            RegisterProgressCareerTransformers(services);
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

        private void RegisterProgressCareerTransformers(IServiceCollection services)
        {
            //Inyeccion de dependencias que configura los IProgressCarreerTransformer correspondientes.
            //https://stackoverflow.com/questions/39174989/how-to-register-multiple-implementations-of-the-same-interface-in-asp-net-core

            var rootPath = Directory.GetCurrentDirectory() + @"\..\ImporterImplementations";
            var progressCarreerTransformerImplementations = _discover.GetProgressCarreerTransformers(rootPath);

            services.AddTransient<ProgressCarreerImplementations>(serviceProvider =>
            {
                return new ProgressCarreerImplementations(progressCarreerTransformerImplementations);
            });

            services.AddTransient<ProgressCarreerTransformerResolver>(serviceProvider => key =>
            {
                var intent = progressCarreerTransformerImplementations.TryGetValue(key, out var value);

                if (!intent)
                {
                    throw new ArgumentException($"There was an error trying to resolve an IProgressCarreerTransformer. Key: {key}");
                }

                return value;
            });
        }
    }
}
