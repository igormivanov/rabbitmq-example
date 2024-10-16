using ExampleRabbitMQ.API2.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace ExampleRabbitMQ.API2.Extensions {
    public static class AppExtensions2 {
        public static void AddRabbitMQService(this IServiceCollection services, IConfiguration configuration) {

            services.AddMassTransit(busConfigurator => {

                busConfigurator.AddConsumer<OrderRequestedEventConsumer>();

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
