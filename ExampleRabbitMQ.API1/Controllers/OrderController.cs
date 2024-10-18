using ExampleRabbitMQ.API1.Dtos;
using Shared.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ExampleRabbitMQ.API1.Models;
using ExampleRabbitMQ.API1.Abstractions;

namespace ExampleRabbitMQ.API1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {

        private readonly IPublishBus _publishBus;

        public OrderController(IPublishBus publishBus) {
            _publishBus = publishBus;
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
            await _publishBus.PubishAsync(eventRequest);

            return Ok(order);
        }
    }
}
