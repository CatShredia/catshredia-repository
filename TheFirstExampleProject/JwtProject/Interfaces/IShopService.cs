using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Interfaces;

public interface IShopService 
{
    // users
    Task<IActionResult> GetAllUsersAsync(int id_role);
    Task<IActionResult> CreateUserAsync(int id_role, UserLoginQuery query);
    Task<IActionResult> UpdateUserAsync(UserLoginQuery query, int id);
    Task<IActionResult> DeleteUserAsync(int id);
    
    // products
    Task<IActionResult> GetAllProductsAsync();
    Task<IActionResult> GetAllProductsWithSortFiltersAsync(
        string? searchTerm = null,     
        string? sortBy = "Id",        
        string? sortOrder = "asc");
    Task<IActionResult> CreateProductAsync(int id_role, ProductQuery query);
    Task<IActionResult> UpdateProductAsync(ProductQuery query, int id);
    Task<IActionResult> DeleteProductAsync(int id);
    
    // orders
    Task<IActionResult> GetAllOrdersAsync();
    Task<IActionResult> CreateOrderAsync(OrderQuery query);
    Task<IActionResult> CancelOrderAsync(int id);
    Task<IActionResult> ChangeYourMindSet(int id, OrderQuery query);
    
    // user actions
    Task<IActionResult> AuthorizationUserAsync([FromBody]LoginQuery reader);
    Task<IActionResult> GetProfileAsync(string Authorization);
    Task<IActionResult> UpdateProfileAsync(string Authorization, UserLoginQuery reader);
    
    // categories
    Task<IActionResult> GetAllCategoriesAsync();
    Task<IActionResult> CreateCategoryAsync(int id_role, CategoryQuery query);
    Task<IActionResult> UpdateCategoryAsync(CategoryQuery query, int id);
    Task<IActionResult> DeleteCategoryAsync(int id);
}