using MassTransit;

namespace ExampleRabbitMQ.API1.Abstractions {
    public interface IPublishBus {

        Task PubishAsync<T>(T message, CancellationToken ct = default) where T : class;
    }

    internal class PublishBus : IPublishBus {

        private readonly IPublishEndpoint _publishEndpoint; 

        public PublishBus(IPublishEndpoint publishEndpoint) {
            this._publishEndpoint = publishEndpoint;
        }

        public Task PubishAsync<T>(T message, CancellationToken ct = default) where T : class {

            return _publishEndpoint.Publish(message);
        }
    }
}
