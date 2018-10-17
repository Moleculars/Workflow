using Bb.Workflow.Service.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Bb.Workflow.Service
{

    /*
        https://bramp.github.io/js-sequence-diagrams/
        https://github.com/bramp/js-sequence-diagrams

        http://flowchart.js.org/
        https://github.com/adrai/flowchart.js
    */

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration accessor
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllEnumsAsStrings();
                swagger.DescribeAllParametersInCamelCase();
                swagger.IgnoreObsoleteActions();
                swagger.AddSecurityDefinition("key", new ApiKeyScheme { Name = "ApiKey" });
                swagger.TagActionsBy(a => a.ActionDescriptor is ControllerActionDescriptor b
                ? b.ControllerTypeInfo.Assembly.FullName.Split('.')[2].Split(',')[0].Replace("Web", "")
                : a.ActionDescriptor.DisplayName
                );

                //swagger.DocInclusionPredicate((f, a) =>
                //{
                //    return a.ActionDescriptor is ControllerActionDescriptor b && b.MethodInfo.GetCustomAttributes<ExternalApiRouteAttribute>().Any();
                //});

                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Black.Beard workflow APIs",
                    License = new License() { Name = "Only usable with a valid partner contract." },
                });

                var doc = DocumentationHelpers.ConcateDocumentations("Black.Beard*.xml");
                if (doc != null)
                    swagger.IncludeXmlComments(() => doc);

            });

            // Initialize workflow configuration
            var ctxBuilder = new HostContextBuilder(Configuration.GetValue<string>("WorkflowConfig"))
                .InitializeLocalStorageWorkflowConfiguration()
                .RegisterWorkflowConfiguration(services);

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First Swagger Environment");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
