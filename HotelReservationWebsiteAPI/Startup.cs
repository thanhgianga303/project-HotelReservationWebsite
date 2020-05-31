using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.Extensions.Logging;
using HotelReservationWebsiteAPI.Mapping;
using HotelReservationWebsiteAPI.Data.Repositories;
using HotelReservationWebsiteAPI.Models.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationWebsiteAPI
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
            services.AddControllers().AddNewtonsoftJson(options =>
                             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
            // services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            // services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();

            services.AddDbContext<HotelReservationWebsiteContext>(options =>
            {
                options.UseSqlite("Data Source=HotelReservationWebsiteContext.db",
              x => x.MigrationsAssembly("HotelReservationWebsiteAPI"));

                options.UseLazyLoadingProxies();
            });


            // services.AddIdentity<ApplicationUser, IdentityRole>()
            //     .AddEntityFrameworkStores<HotelReservationWebsiteContext>()
            //     .AddDefaultTokenProviders();
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.Audience = "admin";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // SeedData(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication(); //IdentityAPI
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapDefaultControllerRoute()
            //         .RequireAuthorization();
            // });
        }
        // private void SeedData(IApplicationBuilder app)
        // {
        //     using (var scope = app.ApplicationServices.CreateScope())
        //     {
        //         var services = scope.ServiceProvider;
        //         var context = services.GetRequiredService<HotelReservationWebsiteContext>();
        //         context.Database.EnsureCreated();
        //         if (!context.Account.Any())
        //         {
        //             context.Account.AddRange(
        //                 new Account()
        //                 {
        //                     Username = "When Harry met Sally",
        //                     Password = "Romantic Comedy"
        //                 },
        //                 new Account()
        //                 {
        //                     Username = "Ghostbusters",
        //                     Password = "Comedy"
        //                 },
        //                 new Account()
        //                 {
        //                     Username = "Ghostbusters 2",
        //                     Password = "Comedy"
        //                 },
        //                 new Account()
        //                 {
        //                     Username = "Rio Bravo",
        //                     Password = "Western"
        //                 });
        //             context.SaveChanges();
        //         }
        //     }
        // }
    }
}
