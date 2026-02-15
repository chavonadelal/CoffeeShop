using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Api.DTOs
{
    public class OrderItemDto 
    {
        [Required(ErrorMessage = "Product ID is required")]
        public Guid ProductId { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }
    }

    public class CreateOrderDto 
    {
        [Required]
        [MinLength(1, ErrorMessage = "Order must contain at least one item")]
        public List<OrderItemDto> Items { get; set; } = new();
    }
}