using System.Text;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using PDS.Data.Context;
using PDS.Data.Repositories;
using PDS.Domain.Interfaces;
using PDS.Domain.Interfaces.ServiceInterfaces;
using PDS.Service.Services;
using PDS.Services.Services;
using PDS.WebApi.Mappings;

namespace PDS.WebApi
{
    public class Startup
    {
       
        //interface fornecida pelo ASP.NET Core
        //que fornece informações sobre o ambiente em que
        //a aplicação está sendo executada
        private IWebHostEnvironment CurrentEnvironment { get; set; }
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {

            _configuration = configuration;

            CurrentEnvironment = env;

            var envFileName = $".env.{CurrentEnvironment.EnvironmentName}";
            var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), envFileName);

            if (!File.Exists(envFilePath) && CurrentEnvironment.EnvironmentName == "Development")
            {
                throw new Exception($"O arquivo env não foi encontrado.");
            }

            DotNetEnv.Env.Load(envFilePath);


        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();


            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PDS",
                    Version = "v1",
                });
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });


            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(AutoMapperDTOs));
            services.AddAutoMapper(typeof(AutoMapperViewModels));
           

            var tokenKey = _configuration.GetSection("AppSettings:Token").Value;

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(tokenKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            services.AddDbContext<DataContext>(o =>
            {
                o.UseNpgsql(connectionString);
            });

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem sucedida!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro de conexão: {ex.Message}");
                }
            }

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAgriculturalProducerRepository, AgriculturalProducerRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRouteRepository, ProductRouteRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IOrderSplittedRepository, OrderSplittedRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAgriculturalProducerService, AgriculturalProducerService>();
            services.AddScoped<IProductRouteService, ProductRouteService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderSplittedService, OrderSplittedService>();
            services.AddScoped<IRouteService, RouteService>();

            services.AddScoped<ITokenService, TokenService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>{ c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDS"); });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}