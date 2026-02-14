namespace CoffeeShop.Api.DTOs
{
    public class OrderItemDto 
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderDto 
    {
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
