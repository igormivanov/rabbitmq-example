using ExampleRabbitMQ.API1.Dtos;
using Shared.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ExampleRabbitMQ.API1.Models;

namespace ExampleRabbitMQ.API1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {

        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] CreateOrderDTO createOrderDTO) {

            var order = new Order() {
                Id = Guid.NewGuid(),
                CustomerName = createOrderDTO.CustomerName,
                Price = createOrderDTO.Price,
                ProductName = createOrderDTO.ProductName,
                Quantity = createOrderDTO.Quantity,
                Status = "Aguardando"
            };

            var eventRequest = new OrderRequestedEvent(order.Id, order.CustomerName);
            await _publishEndpoint.Publish(eventRequest);

            return Ok(order);
        }
    }
}
