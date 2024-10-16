using MassTransit;
using System.Runtime.CompilerServices;

namespace ExampleRabbitMQ.API1.Extensions {
    public static class AppExtensions {

        public static void AddRabbitMQService(this IServiceCollection services) {

            services.AddMassTransit(busConfigurator => {
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
