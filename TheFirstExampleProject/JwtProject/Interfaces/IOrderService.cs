using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Interfaces;

public interface IOrderService
{
    Task<IActionResult> GetAllOrdersAsync();
    Task<IActionResult> CreateOrderAsync(OrderQuery query, string Authorization);
    Task<IActionResult> UpdateProductListAsync(ProductListQuery query, int id);
    Task<IActionResult> ChangeYourMindSet1(int id, string status);
    Task<IActionResult> ChangeYourMindSet2(int id, string deliveryType);
}