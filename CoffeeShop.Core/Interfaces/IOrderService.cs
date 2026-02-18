using CoffeeShop.Core.Commands;
using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(CreateOrderCommand command, CancellationToken cancellationToken = default);
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
