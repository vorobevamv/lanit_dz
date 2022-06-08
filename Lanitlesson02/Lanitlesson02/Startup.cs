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

namespace Client
{
    public class Startup
    {
              // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IValidator<Models.CreateVisitorRequest>, ValidateCreateVisitorRequest>();

            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", host =>
                    {
                        host.Username("guest");

                        host.Password("guest");

                    });
                });
                mt.AddRequestClient<Models.CreateVisitorRequest>(new Uri("rabbitmq://localhost/createvisitor"));  //createvisitor - произвольное имя очереди
            });

            services.AddMassTransitHostedService();
            services.AddTransient<ICreateVisitorCommand, CreateVisitorCommand>();
            


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
