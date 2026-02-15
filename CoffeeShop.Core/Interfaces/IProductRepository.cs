using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;

/// <summary>
/// Contract to resolve product by id. Implemented in Infrastructure (e.g. PostgreSQL).
/// </summary>
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
