using ApplicationServices.Config;
using ApplicationServices.Config.Extension;
using ApplicationServices.UserService;
using ClubSport.Services.UserService;
using Contracts.EventSport;
using Contracts.FieldSport;
using Contracts.HallSport;
using Contracts.Member;
using Contracts.MemberSport;
using Contracts.ProgramSport;
using Contracts.RoleAccess;
using Contracts.ServicesSport;
using Contracts.UserServices;
using DataLayer.Common;
using DataLayer.EventSport;
using DataLayer.FieldSport;
using DataLayer.HallSport;
using DataLayer.ProgramSport;
using DataLayer.RoleAccess;
using DataLayer.ServicesSport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        private const string SecretKey = "ABCneedtogetthisfromenvironmentXYZ";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddOrAuth(appSettings);
            

            services.AddControllersWithViews();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.MaxDepth =20;
               // JsonNamingPolicy.CamelCase
             options.JsonSerializerOptions.PropertyNamingPolicy =  null;
                
            });
         
            services.AddDbContext<ClubSportContext>(c => c.UseSqlServer(Configuration.GetConnectionString("bbb")));

            //
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IEventSportRepository, EventSportRepository>();
            services.AddScoped<IFieldSportRepository, FieldSportRepository>();
            services.AddScoped<IHallSportRepository, HallSportRepository>();
            services.AddScoped<IMemberRepository, DataLayer.Member.MemberRepository>();
            services.AddScoped<IMemberSportRepository, DataLayer.MemberSport.MemberSportRepository>();
            services.AddScoped<IProgramSportRepository, ProgramSportRepository>();
          services.AddScoped<IRoleAccessRepositroy, RoleAccessRepository>();
            services.AddScoped<IServicesSportRepositroy, ServicesSportRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
