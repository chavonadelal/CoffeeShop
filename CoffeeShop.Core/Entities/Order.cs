namespace CoffeeShop.Core.Entities;

public class Order
{
    public Guid Id { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    

    public decimal GetTotalAmount() => Items.Sum(x => x.Price * x.Quantity);
}
