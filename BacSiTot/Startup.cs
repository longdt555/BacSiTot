using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BacSiTot.Helpers;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Repository.Repositories;
using Lib.Repository.Repositories.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BacSiTot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            #region Middleware services

            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(60); });

            #region Allow-Orgin

            services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });

            #endregion

            services.AddControllers();
            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAntiforgery();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region Swagger configuration

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BacSiTot",
                    Version = "v1",
                    Description = ""
                });
                //First we define the security scheme
                c.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType
                            .Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme =
                            "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });

            #endregion

            #region configure strongly typed settings objects

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var jwtSection = Configuration.GetSection("Jwt");
            services.Configure<Jwt>(jwtSection);

            #endregion

            #region auto mapper

            services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperConfig()); });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

            #endregion

            #region Dependency injection - scopes

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region database context

            services.AddDbContext<ApplicationDbContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("BacSiTot-Conn"))); //context

            #endregion

            #region configure jwt authentication

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                //options.Events = new JwtBearerEvents
                //{
                //    OnAuthenticationFailed = context => Task.CompletedTask,
                //    OnTokenValidated = context =>
                //    {
                //        var userId = int.TryParse(context.Principal.Identities.FirstOrDefault()?.Claims.FirstOrDefault(x => x.Type.Equals("USERID"))?.Value, out var id) ? id : 0;
                //        var user = YdConnectorSaver.GetCustomerById(userId);
                //        if (user == null)
                //        {
                //            // return unauthorized if user no longer exists
                //            context.Fail("Unauthorized");
                //        }
                //        CurrentContext.SetLoggedOnClientUser(user);
                //        return Task.CompletedTask;
                //    }
                //};
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            #endregion

            #region services

            services.AddControllersWithViews();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseExceptionHandler("/");

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseSession(); //Add User session

            #region Cors

            app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });

            #endregion

            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {
                var jwToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(jwToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + jwToken);
                }

                await next();
            });

            #region swagger configuration

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
#if DEBUG
                // For Debug in Kestrel
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YD-API V1");
#else
               // To deploy on IIS
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "YD-API V1");
#endif
                c.RoutePrefix = string.Empty;
            });

            #endregion

            #region other configurations

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseAuthentication(); //Add JWToken Authentication service
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            #endregion
        }
    }
}