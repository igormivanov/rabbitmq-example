namespace ExampleRabbitMQ.API1.Dtos {
    public record CreateOrderDTO(
        string CustomerName,
        string ProductName,
        int Quantity,
        decimal Price) {
    }
}
