using AutoMapper.Extensions.ExpressionMapping;
using System.Linq;
using vefast_src.AutoMapper.Profiles;
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
using Microsoft.OData;
using vefast_api.Extension.Swagger;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using vefast_src.Domain.Entities.Categories;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using vefast_src.Domain.Entities.Companes;

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

            //services.AddControllers(mvcOptions =>
            //    mvcOptions.EnableEndpointRouting = false);

            //services.AddControllers().AddOData(options => options.Select().Expand().OrderBy().Filter().SkipToken().SetMaxTop(null).Count());

            //services.AddControllers().AddOData(options =>
            //{
            //    options.EnableQueryFeatures();
            //    var routeOptions = options.AddRouteComponents(GetEdmModel()).Select().Filter().Count().Expand().RouteOptions;

            //    routeOptions.EnableQualifiedOperationCall =
            //    routeOptions.EnableKeyAsSegment =
            //    routeOptions.EnableKeyInParenthesis = true;
            //});
            //services.AddControllers().AddOData(opt => { 
            //    opt.Conventions.Remove(opt.Conventions.OfType<MetadataRoutingConvention>().First()); opt.AddRouteComponents(GetEdmModel()).Select().Filter().Expand().Count().OrderBy().SetMaxTop(100); });


            services.AddControllers().AddOData(opt => opt.Select().Filter().Expand().Count().OrderBy().SetMaxTop(100)
                                            .AddRouteComponents("odata", GetEdmModel()));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
            });

            services.AddAutoMapper(typeof(CompanyProfile));

            services.AddMvc()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.MaxDepth = 2)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddService();
            services.AddInfrastructure(Configuration);


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "VeFaSt-Api", Version = "v1" });
                options.OperationFilter<ODataQueryOptionsFilter>();
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            //services.Configure<ForwardedHeadersOptions>(options =>
            //{
            //    options.KnownProxies.Add(IPAddress.Parse("93.188.167.3"));
            //});

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
            var basePath = "/vefast-api";

            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }
            else
            {
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                    c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" }};
                    });
                });
            }

           

            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "vefast_api v1");
            });

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin();
                //.AllowCredentials();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            //app.UseRequestLocalization();



            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.MapRoute(
            //        name: "default",
            //        template: "vefast-api/{controller=Home}/{action=Index}");
            //    routeBuilder.EnableDependencyInjection();
            //    routeBuilder.Expand().Select().OrderBy().Filter().SkipToken().MaxTop(null).Count();
            //    routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //});

            //app.MapControllers();
            //app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Companes>("Company");
            builder.EntitySet<Categories>("CategoriesOdata");
            //categories.EntityType.Ignore(c => c.name);
            return builder.GetEdmModel();
        }


    }
}
