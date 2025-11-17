using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Model;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly ContextDatabase _context;
    public ProductService(ContextDatabase context) => _context = context;

    public async Task<IActionResult> GetAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return !products.Any()
            ? new NotFoundObjectResult(new { status = false, message = "Products not found." })
            : new OkObjectResult(new { status = true, data = products });
    }

    public async Task<IActionResult> GetAllProductsWithSortFiltersAsync(
        string? searchTerm = null,
        string? sortBy = "Id",
        string? sortOrder = "asc")
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(p => EF.Functions.Like(p.name, $"%{searchTerm}%"));

        sortOrder = sortOrder?.ToLower() == "desc" ? "desc" : "asc";

        query = sortBy?.ToLower() switch
        {
            "name" => sortOrder == "asc" ? query.OrderBy(p => p.name) : query.OrderByDescending(p => p.name),
            "price" => sortOrder == "asc" ? query.OrderBy(p => p.price) : query.OrderByDescending(p => p.price),
            _ => sortOrder == "asc" ? query.OrderBy(p => p.id_product) : query.OrderByDescending(p => p.id_product)
        };

        var products = await query.ToListAsync();
        return !products.Any()
            ? new NotFoundObjectResult(new { status = false, message = "Products not found." })
            : new OkObjectResult(new { status = true, data = products });
    }

    public async Task<IActionResult> CreateProductAsync(int id_role, ProductQuery query)
    {
        var product = new Product
        {
            name = query.name,
            description = query.description,
            price = query.price,
            stroke = query.stroke,
            is_active = query.is_active,
            id_category = query.id_category,
            created_at = DateOnly.FromDateTime(DateTime.UtcNow)
        };

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "Product created successfully." });
    }

    public async Task<IActionResult> UpdateProductAsync(ProductQuery query, int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.id_product == id);
        if (product == null)
            return new NotFoundObjectResult(new { status = false, message = "Product not found." });

        product.name = query.name;
        product.description = query.description;
        product.price = query.price;
        product.stroke = query.stroke;
        product.is_active = query.is_active;
        product.id_category = query.id_category;
        product.updated_at = DateOnly.FromDateTime(DateTime.UtcNow);

        _context.Update(product);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "Product updated successfully." });
    }

    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.id_product == id);
        if (product == null)
            return new NotFoundObjectResult(new { status = false, message = "Product not found." });

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "Product deleted successfully." });
    }

    // === Categories ===

    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return !categories.Any()
            ? new NotFoundObjectResult(new { status = false, message = "Categories not found." })
            : new OkObjectResult(new { status = true, data = categories });
    }

    public async Task<IActionResult> CreateCategoryAsync(int id_role, CategoryQuery query)
    {
        var category = new Category { name = query.name, description = query.description };
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Category created successfully." });
    }

    public async Task<IActionResult> UpdateCategoryAsync(CategoryQuery query, int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.id_category == id);
        if (category == null)
            return new NotFoundObjectResult(new { status = false, message = "Category not found." });

        category.name = query.name;
        category.description = query.description;
        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Category updated successfully." });
    }

    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.id_category == id);
        if (category == null)
            return new NotFoundObjectResult(new { status = false, message = "Category not found." });

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Category deleted successfully." });
    }
}