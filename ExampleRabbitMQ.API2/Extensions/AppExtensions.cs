using ExampleRabbitMQ.API2.Consumers;
using MassTransit;
using System.Runtime.CompilerServices;

namespace ExampleRabbitMQ.API2.Extensions {
    public static class AppExtensions2 {
        public static void AddRabbitMQService(this IServiceCollection services) {

            services.AddMassTransit(busConfigurator => {

                busConfigurator.AddConsumer<OrderRequestedEventConsumer>();

                busConfigurator.UsingRabbitMq((context, configurator) => {

                    configurator.Host(new Uri("amqp://localhost:5672"), host => {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });
        }
    }
}
