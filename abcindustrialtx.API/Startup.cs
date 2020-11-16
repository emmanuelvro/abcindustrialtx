using abcindustrialtx.API.Filters;
using abcindustrialtx.API.Infrastructure;
using abcindustrialtx.Business.Implements;
using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.DAO.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace abcindustrialtx.API
{
    public class Startup
    {
        private readonly MapperConfiguration _mapperConfiguration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("*");
            }
           ));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(auth =>
            {
                auth.RequireHttpsMetadata = true;
                auth.SaveToken = true;
                auth.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Restful:JwtKey"])),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Restful:TokenIssuer"],
                    ValidAudience = Configuration["Restful:TokenIssuer"],
                    ValidateAudience = true
                };
            });
            services.AddDbContext<AbcIndustrialDbContext>(option =>
            {
                option.UseMySQL(Configuration.GetConnectionString("DefaultConnection"),
                    assambly => assambly.MigrationsAssembly("abcindustrialtx.API"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.AddTransient<ICatCalibreDAO, CatCalibreRepository>();
            services.AddTransient<ICatColoresDAO, CatColoresRepository>();
            services.AddTransient<ICatMaterialesDAO, CatMaterialesRepository>();
            services.AddTransient<ICatPresentacionDAO, CatPresentacionRepository>();
            services.AddTransient<IRolesDAO, CatRolesRepository>();
            services.AddTransient<ICatUsuarioDAO, UsuariosRepository>();
            services.AddTransient<IUsuarioRolesDAO, UsuariosRolesRepository>();

            services.AddTransient<ICatCalibresBLL, CatCalibresBLL>();
            services.AddTransient<ICatColoresBLL, CatColoresBLL>();
            services.AddTransient<ICatMaterialesBLL, CatMaterialesBLL>();
            services.AddTransient<ICatPresentacionBLL, CatPresentacionBLL>();
            services.AddTransient<ICatRolesBLL, CatRolesBLL>();
            services.AddTransient<ICatUsuarioBLL, CatUsuarioBLL>();
            services.AddTransient<IUsuariosRolesBLL, UsuariosRolesBLL>();
            services.AddTransient<IProductosDAO, ProductosRepository>();
            services.AddTransient<IProductosBLL, ProductosBLL>();

            services.AddTransient<IProductosColorDAO, ProductosColorRepository>();
            services.AddTransient<IProductosColorBLL, ProductosColorBLL>();
            services.AddTransient<IProductosMaterialDAO, ProductosMaterialRepository>();
            services.AddTransient<IProductosMaterialBLL, ProductosMaterialBLL>();

            services.AddTransient<IPedidosDAO, PedidosRepository>();
            services.AddTransient<IPedidosBLL, PedidosBLL>();

            services.AddTransient<IPedidoDetalleDAO, PedidosDetalleRepository>();
            services.AddTransient<IPedidoDetalleBLL, PedidoDetalleBLL>();

            services.AddSingleton(mapper => _mapperConfiguration.CreateMapper());
            services.AddControllers().AddJsonOptions(options =>
            {
                
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            }).AddNewtonsoftJson(x => {
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                x.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseMiddleware(typeof(GlobalExceptionFilter));
            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }

    
}
