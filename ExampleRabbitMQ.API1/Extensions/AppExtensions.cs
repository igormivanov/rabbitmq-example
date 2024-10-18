using ExampleRabbitMQ.API1.Abstractions;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace ExampleRabbitMQ.API1.Extensions {
    public static class AppExtensions {

        public static void AddRabbitMQService(this IServiceCollection services, IConfiguration configuration) {

            services.AddTransient<IPublishBus, PublishBus>();
            
            services.AddMassTransit(busConfigurator => {
                busConfigurator.UsingRabbitMq((context, configurator) => {

                    configurator.Host(configuration.GetConnectionString("RabbitMq"), host => {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });
        }
    }
}
