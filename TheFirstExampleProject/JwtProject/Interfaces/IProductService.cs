using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Interfaces;

public interface IProductService
{
    Task<IActionResult> GetAllProductsAsync();
    Task<IActionResult> GetAllProductsWithSortFiltersAsync(
        string? searchTerm = null,
        string? sortBy = "Id",
        string? sortOrder = "asc");
    Task<IActionResult> CreateProductAsync(int id_role, ProductQuery query);
    Task<IActionResult> UpdateProductAsync(ProductQuery query, int id);
    Task<IActionResult> DeleteProductAsync(int id);

    // Categories
    Task<IActionResult> GetAllCategoriesAsync();
    Task<IActionResult> CreateCategoryAsync(int id_role, CategoryQuery query);
    Task<IActionResult> UpdateCategoryAsync(CategoryQuery query, int id);
    Task<IActionResult> DeleteCategoryAsync(int id);
}