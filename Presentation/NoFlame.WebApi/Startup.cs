using LightInject;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NoFlame.Core.Interfaces;
using NoFlame.Domain.Repository;
using NoFlame.Infrastructure.Context;
using NoFlame.Infrastructure.Repository;
using NoFlame.Infrastructure.Repository.Authentication;
using NoFlame.Infrastructure.Repository.Behaviors;
using NoFlame.UserServices.User.Auth.Login;
using NoFlame.UserServices.User.Auth.Logout;
using NoFlame.UserServices.User.Auth.RefreshToken;
using NoFlame.UserServices.User.CreateUser;
using NoFlame.UserServices.User.UpdateUserActivity;
using System;
using System.Text;

namespace NoFlame.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionString")));
            services.AddScoped<IApplicationContext, ApplicationContext>();

            services.AddHttpContextAccessor();

            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddMediatR(typeof(CreateUserCommandHandler));
            services.AddMediatR(typeof(UpdateUserActivityCommandHandler));
            services.AddMediatR(typeof(LoginRequestHandler));
            services.AddMediatR(typeof(LogOutRequestHandler));
            services.AddMediatR(typeof(RefreshTokenRequestHandler));

            services.AddScoped<IMediator, Mediator>();

            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
                     
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(GenericPipelineBehavior<,>));
       
            services
                   .AddControllers()
                   .AddNewtonsoftJson(options =>
                   {
                       options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                       options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                       options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                       options.SerializerSettings.Formatting = Formatting.None;
                       options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                   });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoFlame.WebApi", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoFlame.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
