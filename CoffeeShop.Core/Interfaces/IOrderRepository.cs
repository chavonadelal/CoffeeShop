using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;

/// <summary>
/// Persists orders. Implemented in Infrastructure.
/// </summary>
public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken = default);
}
