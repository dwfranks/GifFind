using GifFind.API.Entities;
using GifFind.API.Models;
using GifFind.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GifFind.API.Services;

namespace GifFind.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions( // Added to ignore referencing loop due to Entity Helpers
                    options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version"));

            //Config Automapper
            services.AddAutoMapper(typeof(Startup));

            // Config IOC Services
            services.AddHttpClient<IAppClient, GiphyClientService>();

            // Add CORS Policy
            services.AddCors(option =>
            {
                option.AddPolicy("AllowSubdomain",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Configure db connection
            services.AddDbContext<GifFindContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GifFindDatabase")));

            // Add Identity
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<GifFindContext>()
                    .AddDefaultTokenProviders();

            // Map IoC
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISavedImageService, SavedImageService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "GIF Find", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                        new ApiKeyScheme
                        {
                            In = "header",
                            Description = "Please enter into field the word 'Bearer' following by space and JWT",
                            Name = "Authorization",
                            Type = "apiKey"
                        });
                                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                        { "Bearer", Enumerable.Empty<string>() },
                    });
            });
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
                app.UseHsts();
            }

            // Enable Swagger
            app.UseSwagger();
            // Set Swagger Endpoint and serve at app root
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "GIF Find API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("AllowSubdomain");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }

        public IConfiguration Configuration { get; }
    }
}
