using CoffeeShop.Core.Commands;
using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;

namespace CoffeeShop.Application.Services;

public class OrderService : IOrderService
{
    private readonly IProductRepository _productRepository;

    public OrderService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        if (command.Items is null || command.Items.Count == 0)
            throw new ArgumentException("Order must have at least one item.", nameof(command));

        var orderItems = new List<OrderItem>();

        foreach (var item in command.Items)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
            if (product is null)
                throw new InvalidOperationException($"Product not found: {item.ProductId}.");

            orderItems.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = item.Quantity
            });
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Items = orderItems
        };

        return order;
    }
}
