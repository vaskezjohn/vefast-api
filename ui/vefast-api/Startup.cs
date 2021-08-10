using AutoMapper.Extensions.ExpressionMapping;
using System.Linq;
using vafast_src.AutoMapper.Profiles;
using vafast_src.Domain.Entities.Company;
using vefast_api.Extension.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
//using Microsoft.OData.ModelBuilder;
//using Microsoft.AspNetCore.OData;
//using Microsoft.AspNetCore.OData.Routing.Conventions;
using System;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using vefast_api.Extension.Swagger;

namespace vefast_api
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
            services.AddAutoMapper(cfg => {
                cfg.AddExpressionMapping();
            });

            services.AddAutoMapper(typeof(CompanyProfile));

            services.AddMvc()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.MaxDepth = 2)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);          

            services.AddService();
            services.AddInfrastructure(Configuration);

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);
            services.AddOData();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "VEFAST-API", Version = "v1" });
                options.OperationFilter<ODataQueryOptionsFilter>();
            });

            services.AddMvcCore(options =>
            {
                options.AllowEmptyInputInBodyModelBinding = true;
                options.EnableEndpointRouting = false;

                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vefast_api v1"));
            //app.UseCors(builder =>
            //{
            //    builder.AllowAnyHeader()
            //           .AllowAnyMethod()
            //           .AllowAnyOrigin();
            //    //.AllowCredentials();
            //});

            app.UseHttpsRedirection();
            app.UseRouting();            
            app.UseAuthorization();

            app.UseRequestLocalization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().OrderBy().Filter().SkipToken().MaxTop(null).Count();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Company>("Company");

            return odataBuilder.GetEdmModel();
        }

      
    }
}
