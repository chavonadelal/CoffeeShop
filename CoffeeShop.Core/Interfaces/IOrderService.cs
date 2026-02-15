using CoffeeShop.Core.Commands;
using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;

public interface IOrderService
{
    Order CreateOrder(CreateOrderCommand command);
}
