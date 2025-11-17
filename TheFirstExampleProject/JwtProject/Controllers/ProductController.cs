using JwtProject.Interfaces;
using JwtProject.Queries;
using JwtProject.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class ProductController
{
    private readonly IProductService _service;
    public ProductController(IProductService service) => _service = service;

    [HttpGet("product/all")]
    [Role([1])]
    public async Task<IActionResult> GetAllProducts() => await _service.GetAllProductsAsync();
    
    [HttpGet("product/allWithSortFilters")]
    [Role([3])]
    public async Task<IActionResult> GetAllProductsWithSortFilters(
        string? searchTerm = null,     
        string? sortBy = "Id",        
        string? sortOrder = "asc") 
        => await _service.GetAllProductsWithSortFiltersAsync(searchTerm, sortBy, sortOrder);

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

    // category
    [HttpGet("category/all")]
    [Role([1])]
    public async Task<IActionResult> GetAllCategories() => await _service.GetAllCategoriesAsync();

    [HttpPost("category/create")]
    [Role([1])]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryQuery reader) =>
        await _service.CreateCategoryAsync(2, reader);

    [HttpPut("category/update")]
    [Role([1])]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryQuery reader, int id) =>
        await _service.UpdateCategoryAsync(reader, id);

    [HttpDelete("category/delete")]
    [Role([1])]
    public async Task<IActionResult> DeleteCategory(int id) => await _service.DeleteCategoryAsync(id);
}