using AppointmentManagement.Business.Abstract;
using AppointmentManagement.Business.Abstract.Procedure;
using AppointmentManagement.Business.Concrete;
using AppointmentManagement.Business.Concrete.Procedure;
using AppointmentManagement.Core.DataAccess;
using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.DataAccess.Abstract.Procedure;
using AppointmentManagement.DataAccess.Concrete;
using AppointmentManagement.DataAccess.Concrete.Procedure;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.UI.Entity.Abstract;
using AppointmentManagement.UI.Entity.Concrete;
using AppointmentManagement.UI.Identity.Context;
using AutoMapper;
using CivilManagement.UI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;

namespace CivilManagement.UI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            //Service
            services.AddScoped<IDataService, EfDataService>();
            services.AddScoped<IVehicleServiceService, EfVehicleServiceService>();
            services.AddScoped<IPostedServiceService, EfPostedServiceService>();
            services.AddScoped<IOrderWarehouseService, EfOrderWarehouseService>();
            services.AddScoped<ITrOrderAsnHeaderService, EfTrOrderAsnHeaderService>();

            //Dataaccess
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDataProcedure, EfDataProcedure>();
            services.AddScoped<IVehicleTypesDal, EfVehicleTypesDal>();
            services.AddScoped<IPostedTypeDal, EfPostedTypeDal>();
            services.AddScoped<IOrderWarehouseDal, EfOrderWarehouseDal>();

            services.AddScoped<IAppointment, EfAppointment>();

            services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepository<>));



            services.AddHttpContextAccessor();

            services.AddDbContext<EfCivilContext>(opts =>
            {
                opts.UseSqlServer(_configuration.GetConnectionString("NebimV3Connection"));
            });

            services.AddDbContext<EfAppointmentContext>(opts =>
            {
                opts.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<AppIdentityDbContext>(opts =>
            {
                opts.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = new PathString("/Account/Denied");
                options.Cookie.Name = "Appointment.Cookie";
                options.SlidingExpiration = true;
            });



            services.AddControllersWithViews();

            services.AddRazorPages()
                      .AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            //RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            //{


            //    SupportedCultures = new List<CultureInfo> { new CultureInfo("en-EN") { } },
            //    SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-EN") },
            //    DefaultRequestCulture = new RequestCulture("en-EN")
            //};


            app.UseStatusCodePages();

            //app.UseRequestLocalization(localizationOptions);
            //app.UseRequestLocalization(opt =>
            //{

            //    opt.DefaultRequestCulture = new RequestCulture("tr-TR");
            //    opt.DefaultRequestCulture.Culture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
            //    opt.DefaultRequestCulture.Culture.DateTimeFormat.DateSeparator = "/";
            //});

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}
