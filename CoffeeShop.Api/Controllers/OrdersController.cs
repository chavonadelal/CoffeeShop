using CoffeeShop.Api.DTOs;
using CoffeeShop.Core.Commands;
using CoffeeShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateOrderDto dto)
    {
        var command = new CreateOrderCommand
        {
            Items = dto.Items.Select(x => new CreateOrderItemCommand
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()
        };

        var order = _orderService.CreateOrder(command);

        return Ok(new
        {
            order.Id,
            order.CreatedAt,
            TotalAmount = order.GetTotalAmount(),
            ItemsCount = order.Items.Count
        });
    }
}
