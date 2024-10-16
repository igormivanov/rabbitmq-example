using MassTransit;
using Shared.Events;

namespace ExampleRabbitMQ.API2.Consumers {
    public class OrderRequestedEventConsumer : IConsumer<OrderRequestedEvent> {

        private readonly ILogger _logger;

        public OrderRequestedEventConsumer(ILogger<OrderRequestedEventConsumer> logger) { 
            _logger = logger; 
        }
        public async Task Consume(ConsumeContext<OrderRequestedEvent> context) {

            var message = context.Message;

            _logger.LogInformation("Processando Pedido {id} do {name}", message.Id, message.CustomerName);

            await Task.Delay(5000);

            _logger.LogInformation("Pedido processado! Id:{id}, Nome:{name}", message.Id, message.CustomerName);
        }
    }
}
