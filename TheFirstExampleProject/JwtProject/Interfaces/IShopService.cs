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
    Task<IActionResult> GetAllProductsAsync(int id_role);
    Task<IActionResult> CreateProductAsync(int id_role, ProductQuery query);
    Task<IActionResult> UpdateProductAsync(ProductQuery query, int id);
    Task<IActionResult> DeleteProductAsync(int id);
}