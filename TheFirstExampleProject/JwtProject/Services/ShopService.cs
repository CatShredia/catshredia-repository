using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Model;
using JwtProject.Models;
using JwtProject.Queries;
using JwtProject.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.Services;

public class ShopService : IShopService
{
    private readonly ContextDatabase _contextDatabase;
    private readonly JwtTokensGenerator _jwtGenerator;

    public ShopService(ContextDatabase contextDatabase, JwtTokensGenerator jwtGenerator)
    {
        _contextDatabase = contextDatabase;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<IActionResult> GetAllUsersAsync(int id_role)
    {
        var employeesList = _contextDatabase.Users
            .Where(user => user.id_role == id_role);

        if (employeesList == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Users not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = employeesList
        });
    }

    public async Task<IActionResult> CreateUserAsync(int _id_role, UserLoginQuery query)
    {
        var newLogin = new Login()
        {
            User = new User()
            {
                name = query.nameUser,
                description = query.description,
                id_role = _id_role
            },
            password = query.password,
            login = query.login,
        };

        await _contextDatabase.AddAsync(newLogin);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login created successfully."
        });
    }

    public async Task<IActionResult> UpdateUserAsync(UserLoginQuery query, int id)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        existingLogin.login = query.login;
        existingLogin.password = query.password;

        existingLogin.User.name = query.nameUser;
        existingLogin.User.description = query.description;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login edited successfully."
        });
    }

    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        _contextDatabase.Logins.Remove(existingLogin);

        if (existingLogin.User != null)
        {
            _contextDatabase.Users.Remove(existingLogin.User);
        }

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login deleted successfully."
        });
    }

    public async Task<IActionResult> GetAllProductsAsync()
    {
        var productsList = _contextDatabase.Products;

        if (!productsList.Any())
        {
            return new NotFoundObjectResult(new { status = false, message = "Products not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = productsList
        });
    }

    public async Task<IActionResult> GetAllProductsWithSortFiltersAsync(
        string? searchTerm = null,     
        string? sortBy = "Id",        
        string? sortOrder = "asc")    
    {
        var query = _contextDatabase.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(p =>
                EF.Functions.Like(p.name, $"%{searchTerm}%"));
        }

        sortOrder = sortOrder?.ToLower() == "desc" ? "desc" : "asc";
    
        query = sortBy?.ToLower() switch
        {
            "name" => sortOrder == "asc" 
                ? query.OrderBy(p => p.name) 
                : query.OrderByDescending(p => p.name),
            "price" => sortOrder == "asc" 
                ? query.OrderBy(p => p.price) 
                : query.OrderByDescending(p => p.price),
            _ => sortOrder == "asc" 
                ? query.OrderBy(p => p.id_product) 
                : query.OrderByDescending(p => p.id_product) 
        };

        var productsList = await query.ToListAsync();

        if (!productsList.Any())
        {
            return new NotFoundObjectResult(new { status = false, message = "Products not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = productsList
        });
    }

    public async Task<IActionResult> CreateProductAsync(int id_role, ProductQuery query)
    {
        var newProduct = new Product()
        {
            name = query.name,
            description = query.description,
            price = query.price,
            stroke = query.stroke,
            is_active = query.is_active,
            id_category = query.id_category,
            created_at = DateOnly.FromDateTime(DateTime.UtcNow),
            updated_at = null
        };

        await _contextDatabase.AddAsync(newProduct);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Product created successfully."
        });
    }

    public async Task<IActionResult> UpdateProductAsync(ProductQuery query, int id)
    {
        var existingProduct = await _contextDatabase.Products
            .FirstOrDefaultAsync(p => p.id_product == id);

        if (existingProduct == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Product not found." });
        }

        existingProduct.name = query.name;
        existingProduct.description = query.description;
        existingProduct.price = query.price;
        existingProduct.stroke = query.stroke;
        existingProduct.is_active = query.is_active;
        existingProduct.id_category = query.id_category;
        existingProduct.updated_at = DateOnly.FromDateTime(DateTime.UtcNow);

        _contextDatabase.Update(existingProduct);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Product edited successfully."
        });
    }

    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var existingProduct = await _contextDatabase.Products
            .FirstOrDefaultAsync(p => p.id_product == id);

        if (existingProduct == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Product not found." });
        }

        _contextDatabase.Products.Remove(existingProduct);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Product deleted successfully."
        });
    }

    public async Task<IActionResult> GetAllOrdersAsync()
    {
        var orderList = _contextDatabase.Orders
            .Select(order => new
            {
                id_order = order.id_order,
                status = order.OrderStatus,
                deliveryType = order.OrderDeliveryType,
                address = order.address,
                orderItems = _contextDatabase.OrderLists
                    .Where(ol => ol.id_order == order.id_order)
                    .Select(ol => ol.id_product)
                    .ToList()
            })
            .ToListAsync();

        if (orderList == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Orders not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = orderList
        });
    }

    public async Task<IActionResult> CreateOrderAsync(OrderQuery query)
    {
        var newOrder = new Order()
        {
            OrderStatus = query.status,
            OrderDeliveryType = query.deliveryType,
            address = query.address,
            // TODO: after auth
            id_user = 1
        };

        await _contextDatabase.AddAsync(newOrder);
        await _contextDatabase.SaveChangesAsync();

        foreach (var _id_product in query.ids_products)
        {
            var newOrderList = new OrderList()
            {
                id_order = newOrder.id_order,
                id_product = _id_product,
            };
            await _contextDatabase.AddAsync(newOrderList);
        }

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Order and Order List created successfully."
        });
    }

    public async Task<IActionResult> CancelOrderAsync(int id)
    {
        var selectedOrder = await _contextDatabase.Orders
            .FirstOrDefaultAsync(p => p.id_order == id);

        if (selectedOrder == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Order not found." });
        }

        // selectedOrder.OrderStatus = _contextDatabase.Order;

        _contextDatabase.Update(selectedOrder);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Order canceled successfully."
        });
    }

    public async Task<IActionResult> ChangeYourMindSet(int id, OrderQuery query)
    {
        var existingOrder = await _contextDatabase.Orders
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingOrder == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Order not found." });
        }

        existingOrder.OrderStatus = query.status;
        existingOrder.OrderDeliveryType = query.deliveryType;
        existingOrder.address = query.address;
        existingOrder.OrderStatus = query.status;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Order changed successfully."
        });
    }

    public async Task<IActionResult> AuthorizationUserAsync(LoginQuery query)
    {
        var selectedUser = _contextDatabase.Logins
            .Include(login => login.User)
            // .ThenInclude(user => user.Role)
            .FirstOrDefault(login => login.login == query.name && login.password == query.password);

        if (selectedUser != null)
        {
            string token = _jwtGenerator.GenerateJwtToken(selectedUser.id_user, selectedUser.User.id_role);

            _contextDatabase.Sessions.Add(new Session()
            {
                name = token,
                id_user = selectedUser.id_user,
            });
            await _contextDatabase.SaveChangesAsync();

            return new OkObjectResult(new { status = true, data = token });
        }
        else
        {
            return new NotFoundObjectResult(new
                { status = false, message = "User not found. Check you login and password!" });
        }
    }

    public async Task<IActionResult> GetProfileAsync(string Authorization)
    {
        var selectedUser = _contextDatabase.Sessions
            .Include(session => session.User)
            .FirstOrDefault(session => session.name == Authorization);
        if (selectedUser != null)
        {
            return new OkObjectResult(new { status = true, selectedUser = selectedUser });
        }
        else
        {
            return new NotFoundObjectResult(new
                { status = false, message = "Session not founded!" });
        }
    }

    public async Task<IActionResult> UpdateProfileAsync(string Authorization, UserLoginQuery reader)
    {
        var selectedSession = _contextDatabase.Sessions.FirstOrDefault(session => session.name == Authorization);

        if (selectedSession != null)
        {
            var existingLogin = await _contextDatabase.Logins
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.id_user == selectedSession.id_user);

            if (existingLogin == null)
            {
                return new NotFoundObjectResult(new { status = false, message = "Login not found." });
            }

            existingLogin.login = reader.login;
            existingLogin.password = reader.password;

            existingLogin.User.name = reader.nameUser;
            existingLogin.User.description = reader.description;

            await _contextDatabase.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "User and login edited successfully."
            });
        }
        else
        {
            return new NotFoundObjectResult(new
                { status = false, message = "Session not founded!" });
        }
    }
    
    // categories
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        var categoriesList = _contextDatabase.Categories;
        if (categoriesList == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Categories not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = categoriesList
        });
    }

    public async Task<IActionResult> CreateCategoryAsync(int _id_role, CategoryQuery query)
    {
        var newCategory = new Category()
        {
            name = query.name,
            description = query.description,
        };

        await _contextDatabase.AddAsync(newCategory);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Category created successfully."
        });
    }

    public async Task<IActionResult> UpdateCategoryAsync(CategoryQuery query, int id)
    {
        var existingCategory = await _contextDatabase.Categories
            .FirstOrDefaultAsync(l => l.id_category == id);

        if (existingCategory == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Category not found." });
        }

        existingCategory.name = query.name;
        existingCategory.description = query.description;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Category edited successfully."
        });
    }

    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        var existingCategory = await _contextDatabase.Categories
            .FirstOrDefaultAsync(l => l.id_category == id);

        if (existingCategory == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Category not found." });
        }

        _contextDatabase.Categories.Remove(existingCategory);
        
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Category deleted successfully."
        });
    }
}