using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Authorization.Handlers;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace HotelReservationWebsite
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
            services.Configure<AppSettings>(Configuration);
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddHttpClient<HotelReservationWebsite.Infrastructure.IHttpClient, CustomHttpClient>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomCategoryService, RoomCategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityService<Buyer>, IdentityService>();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc"; //Account/User
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;
                    // options.Notifications = new AuthorizationCodeReceived()
                    // {

                    // }
                    // options.ClaimActions.Add(new RoleClaimAction());
                    options.Scope.Add("admin");
                    options.Scope.Add("offline_access");
                    options.Scope.Add("roles");
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {

                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };

                });

            services.AddScoped<IAuthorizationHandler, OwnerAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RoomOwnerAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, ManagersAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, AdministratorsAuthorizationHandler>();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            // services.AddAuthentication("Bearer")
            // .AddJwtBearer("Bearer", options =>
            // {
            //     options.Authority = "http://localhost:5000";
            //     options.RequireHttpsMetadata = false;

            //     options.Audience = "admin";
            // });
            //     services.AddAuthorization(options =>
            // options.AddPolicy("AdminApp",
            //     policy => policy.RequireClaim("Admin")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapAreaControllerRoute(
                // name: "AreaAdmin",
                // areaName: "Admin",
                // pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });
        }
    }
}
