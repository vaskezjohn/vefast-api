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
using vefast_src.Domain.Entities.Companies;
using vefast_src.Domain.Entities.Users;
using vefast_src.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerUI;
using Serilog;

namespace vefast_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.MySQL(
                    connectionString: configuration.GetConnectionString("vefast"))
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers(mvcOptions =>
            //    mvcOptions.EnableEndpointRouting = false);

            services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                //options.Password.RequiredLength = 15;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedEmail = true;
            })
                    .AddEntityFrameworkStores<VefastDataContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
                    ValidAudience = Configuration["JwtSecurityToken:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Secret"]))
                };
            });


            services.AddControllers().AddOData(opt => opt.Select().Filter().Expand().Count().OrderBy().SetMaxTop(100)
                                            .AddRouteComponents("odata", GetEdmModel()));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
            });

            services.AddAutoMapper(typeof(CompaniesProfile));
            services.AddAutoMapper(typeof(UsersProfile));

            services.AddMvc()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.MaxDepth = 2)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddService();
            services.AddInfrastructure(Configuration);


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VeFaSt-Api",
                    Version = "v1"
                });
                options.OperationFilter<ODataQueryOptionsFilter>();
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Autorización",
                    Description = "Ingrese el token de autorización (JWT)",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "Bearer {token}",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                });
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //          new OpenApiSecurityScheme
                //            {
                //                Reference = new OpenApiReference
                //                {
                //                    Type = ReferenceType.SecurityScheme,
                //                    Id = "Bearer"
                //                }
                //            },
                //            new string[] {}
                //    }
                //});
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", build =>
                    build.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var basePath = "/vefast-api";

            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                });
            }
            else
            {
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                    c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" } };
                    });
                });
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "VeFaSt API");
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
            app.UseAuthentication();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Companies>("Company");
            builder.EntitySet<Categories>("CategoriesOdata");
            var usersConfig = builder.EntitySet<Users>("UsersOdata");

            usersConfig.EntityType.Ignore(c => c.PasswordHash);
            usersConfig.EntityType.Ignore(c => c.AccessToken);
            usersConfig.EntityType.Ignore(c => c.LockoutEnd);
            usersConfig.EntityType.Ignore(c => c.ConcurrencyStamp);
            usersConfig.EntityType.Ignore(c => c.SecurityStamp);

            return builder.GetEdmModel();
        }


    }
}
