using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Model;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly ContextDatabase _context;
    public OrderService(ContextDatabase context) => _context = context;

    public async Task<IActionResult> GetAllOrdersAsync()
    {
        var orders = await _context.Orders
            .Select(o => new
            {
                o.id_order,
                status = o.OrderStatus,
                deliveryType = o.OrderDeliveryType,
                o.address,
                orderItems = _context.OrderLists
                    .Where(ol => ol.id_order == o.id_order)
                    .Select(ol => ol.id_product)
                    .ToList()
            })
            .ToListAsync();

        return !orders.Any()
            ? new NotFoundObjectResult(new { status = false, message = "Orders not found." })
            : new OkObjectResult(new { status = true, data = orders });
    }

    public async Task<IActionResult> CreateOrderAsync(OrderQuery query, string Authorization)
    {
        var session = await _context.Sessions
            .FirstOrDefaultAsync(s => s.name == Authorization);
        
        if (session == null)
            return new NotFoundObjectResult(new { status = false, message = "Session not found." });
        
        var order = new Order
        {
            id_status = query.id_status,
            id_delivery_type = query.id_delivery_type,
            address = query.address,
            id_user = session.id_user
        };

        await _context.AddAsync(order);
        await _context.SaveChangesAsync();

        foreach (var id in query.ids_products)
        {
            await _context.AddAsync(new OrderList { id_order = order.id_order, id_product = id });
        }

        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Order created successfully." });
    }
    
    public async Task<IActionResult> UpdateProductListAsync(ProductListQuery query, int _id_order)
    {
        var selectedLists = await _context.OrderLists
            .Where(ol => ol.id_order == _id_order)
            .ToListAsync();

        if (selectedLists == null)
            return new NotFoundObjectResult(new { status = false, message = "Order not found." });
        
        _context.OrderLists.RemoveRange(selectedLists);

        foreach (var id in query.productList)
        {
            _context.OrderLists.Add(new OrderList { id_order = _id_order, id_product = id });
        }

        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "OrderList updated successfully." });
    }

    public async Task<IActionResult> ChangeYourMindSet1(int id, string status)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.id_user == id);
        if (order == null)
            return new NotFoundObjectResult(new { status = false, message = "Order not found." });

        var selectedStatus = _context.OrderStatus.FirstOrDefault(s => s.name == status);
        if (selectedStatus == null)
            return new NotFoundObjectResult(new { status = false, message = "Status not found." });

        order.OrderStatus = selectedStatus;

        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Order updated successfully." });
    }
    
    public async Task<IActionResult> ChangeYourMindSet2(int id, string deliveryType)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.id_user == id);
        if (order == null)
            return new NotFoundObjectResult(new { status = false, message = "Order not found." });

        var selectedDeliveryType = _context.OrderStatus.FirstOrDefault(s => s.name == deliveryType);
        if (selectedDeliveryType == null)
            return new NotFoundObjectResult(new { status = false, message = "Type not found." });
        
        order.OrderStatus = selectedDeliveryType;

        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Order updated successfully." });
    }
}