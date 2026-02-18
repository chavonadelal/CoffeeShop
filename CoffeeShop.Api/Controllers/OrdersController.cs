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
    public async Task<IActionResult> Create([FromBody] CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var command = new CreateOrderCommand
        {
            Items = dto.Items.Select(x => new CreateOrderItemCommand
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()
        };

        var order = await _orderService.CreateOrderAsync(command, cancellationToken);

        return Ok(new
        {
            order.Id,
            order.CreatedAt,
            TotalAmount = order.GetTotalAmount(),
            ItemsCount = order.Items.Count
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetByIdAsync(id, cancellationToken);
        if (order is null)
            return NotFound();

        return Ok(new
        {
            order.Id,
            order.CreatedAt,
            TotalAmount = order.GetTotalAmount(),
            Items = order.Items.Select(i => new
            {
                i.Id,
                i.ProductId,
                i.Name,
                i.Price,
                i.Quantity,
                LineTotal = i.Price * i.Quantity
            })
        });
    }
}
