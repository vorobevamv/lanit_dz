using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MassTransit;

namespace Service
{
    public class Startup
    {
      
        public Startup()
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                con.Database.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<CreateVisitorConsumer>();
                mt.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", host =>
                    {
                        host.Username("guest");

                        host.Password("guest");

                    });
                    config.ReceiveEndpoint("createvisitor", x =>
                    {
                        x.ConfigureConsumer<CreateVisitorConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddTransient<IVisitorRepository, VisitorsRepository>(); 
            services.AddTransient<ICreateVisitorRequestMapper, CreateVisitorRequestMapper>();
            services.AddTransient<ICreateVisitorResponseMapper, CreateVisitorResponseMapper>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
