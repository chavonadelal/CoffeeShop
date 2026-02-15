namespace CoffeeShop.Core.Commands;

/// <summary>
/// What the API sends to Application: only product id and quantity per item.
/// </summary>
public class CreateOrderCommand
{
    public List<CreateOrderItemCommand> Items { get; set; } = new();
}

public class CreateOrderItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
