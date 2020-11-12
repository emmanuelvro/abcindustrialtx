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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
            services.AddTransient<IExistenciaMaterialesDAO, ExistenciaMaterialesRepository>();
            services.AddTransient<IHilosExistenciaDAO, HilosExistenciaRepository>();
            services.AddTransient<IHilosProductoMaterialDAO, HilosProductoMaterialRepository>();
            services.AddTransient<IHilosProductosPedidosDAO, HilosProductosPedidosRepository>();
            services.AddTransient<IHilosProductosDAO, HilosProductosRepository>();
            services.AddTransient<IProductoPresentacionDAO, ProductoPresentacionRepository>();
            services.AddTransient<IUsuarioRolesDAO, UsuariosRolesRepository>();

            services.AddTransient<ICatCalibresBLL, CatCalibresBLL>();
            services.AddTransient<ICatColoresBLL, CatColoresBLL>();
            services.AddTransient<ICatMaterialesBLL, CatMaterialesBLL>();
            services.AddTransient<ICatPresentacionBLL, CatPresentacionBLL>();
            services.AddTransient<ICatRolesBLL, CatRolesBLL>();
            services.AddTransient<ICatUsuarioBLL, CatUsuarioBLL>();
            services.AddTransient<IHilosExistenciaBLL, HilosExistenciaBLL>();
            services.AddTransient<IHilosProductoMaterialBLL, HilosProductoMaterialBLL>();
            services.AddTransient<IHilosProductosBLL, HilosProductosBLL>();
            services.AddTransient<IHilosProductosPedidosBLL, HilosProductosPedidosBLL>();
            services.AddTransient<IProductoPresentacionBLL, ProductoPresentacionBLL>();
            services.AddTransient<IUsuariosRolesBLL, UsuariosRolesBLL>();

            services.AddSingleton(mapper => _mapperConfiguration.CreateMapper());
            services.AddControllers().
                AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.PropertyNamingPolicy = null;
                }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
