using CoffeeShop.Core.Commands;
using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;

namespace CoffeeShop.Application.Services;

public class OrderService : IOrderService
{
    public Order CreateOrder(CreateOrderCommand command)
    {
        if (command.Items is null || command.Items.Count == 0)
            throw new ArgumentException("Order must have at least one item.", nameof(command));

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Items = command.Items.Select(item => new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = item.ProductId,
                Name = "",   // TODO: get from DB later
                Price = 0m,  // TODO: get from DB later
                Quantity = item.Quantity
            }).ToList()
        };

        return order;
    }
}
