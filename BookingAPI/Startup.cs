using AutoMapper;
using BookingAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BookingAPI.Data;
using BookingAPI.Data.Repositories;
using BookingAPI.DTOs;
// using BookingAPI.Infrastructure.Filters;
using BookingAPI.Models;
using MassTransit;
using BookingAPI.Consumers;
using GreenPipes;

namespace BookingApi
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
            services.AddControllers().AddNewtonsoftJson(options =>
                             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<AppSettings>(Configuration);
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<BookingContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionString"]);
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking API", Version = "v1" });
            });
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ListHotelConsumer>();
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost", h => { h.Username("guest"); h.Password("guest"); });

                    cfg.ReceiveEndpoint("order-api", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<ListHotelConsumer>(context);
                    });
                }));
            });

            services.AddHostedService<BusService>();

            services.AddMassTransitHostedService();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
                });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
