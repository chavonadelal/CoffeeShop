namespace CoffeeShop.Core.Entities;

/// <summary>
/// Domain entity for product lookup. No EF attributes — mapping lives in Infrastructure.
/// </summary>
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
