using JwtProject.Interfaces;
using JwtProject.Queries;
using JwtProject.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class ProductController
{
    private readonly IShopService _service;
    public ProductController(IShopService service) => _service = service;

    [HttpGet("product/all")]
    [Role([1])]
    public async Task<IActionResult> GetAllProducts() => await _service.GetAllProductsAsync(2);

    [HttpPost("product/create")]
    [Role([1])]
    public async Task<IActionResult> CreateProduct([FromBody] ProductQuery reader) =>
        await _service.CreateProductAsync(2, reader);

    [HttpPut("product/update")]
    [Role([1])]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductQuery reader, int id) =>
        await _service.UpdateProductAsync(reader, id);

    [HttpDelete("product/delete")]
    [Role([1])]
    public async Task<IActionResult> DeleteProduct(int id) => await _service.DeleteProductAsync(id);
}