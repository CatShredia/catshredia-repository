using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class ProductController
{
    private readonly IShopService _service;
    public ProductController(IShopService service) => _service = service;
    
    [HttpGet("product/all")]
    public async Task<IActionResult> GetAllProducts() => await _service.GetAllProductsAsync(2);
    [HttpPost("product/create")]
    public async Task<IActionResult> CreateProduct([FromBody]ProductQuery reader) => await _service.CreateProductAsync(2, reader);
    [HttpPut("product/update")]
    public async Task<IActionResult> UpdateProduct([FromBody]ProductQuery reader, int id) => await _service.UpdateProductAsync(reader, id);
    [HttpDelete("product/delete")]
    public async Task<IActionResult> DeleteProduct(int id) => await _service.DeleteProductAsync(id);

}