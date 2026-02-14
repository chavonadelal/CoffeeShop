using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;

public interface IOrderService
{
    Order CreateOrder(List<OrderItem> items);
}
