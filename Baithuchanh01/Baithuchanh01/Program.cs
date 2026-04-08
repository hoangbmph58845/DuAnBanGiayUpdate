using Microsoft.EntityFrameworkCore;
using Baithuchanh01.Data;
using Baithuchanh01.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Cấu hình EF Core với SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Thêm Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Swagger UI cho môi trường Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var categoryGroup = app.MapGroup("/api/categories");

// GET: Lấy tất cả category
categoryGroup.MapGet("/", async (AppDbContext db) =>
{
    var categories = await db.Categories
        .Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        }).ToListAsync();

    return Results.Ok(categories);
});

// GET: Lấy category theo Id
categoryGroup.MapGet("/{id:int}", async (int id, AppDbContext db) =>
{
    var category = await db.Categories
        .Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        })
        .FirstOrDefaultAsync(c => c.Id == id);

    return category is null ? Results.NotFound() : Results.Ok(category);
});

// POST: Tạo mới category
categoryGroup.MapPost("/", async (CreateCategoryDto dto, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name))
        return Results.BadRequest("Category name is required.");

    var category = new Category
    {
        Name = dto.Name,
        Description = dto.Description
    };

    db.Categories.Add(category);
    await db.SaveChangesAsync();

    return Results.Created($"/api/categories/{category.Id}", category);
});

// PUT: Cập nhật category
categoryGroup.MapPut("/{id:int}", async (int id, UpdateCategoryDto dto, AppDbContext db) =>
{
    var category = await db.Categories.FindAsync(id);
    if (category == null) return Results.NotFound();

    category.Name = dto.Name ?? category.Name;
    category.Description = dto.Description ?? category.Description;

    await db.SaveChangesAsync();
    return Results.Ok(category);
});

// DELETE: Xóa category
categoryGroup.MapDelete("/{id:int}", async (int id, AppDbContext db) =>
{
    var category = await db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    if (category == null) return Results.NotFound();

    if (category.Products.Any())
        return Results.BadRequest("Cannot delete category that still has products.");

    db.Categories.Remove(category);
    await db.SaveChangesAsync();
    return Results.Ok($"Category {id} deleted successfully.");
});


var productGroup = app.MapGroup("/api/products");

// GET: Lấy tất cả sản phẩm
productGroup.MapGet("/", async (AppDbContext db) =>
{
    var products = await db.Products
        .Include(p => p.Category)
        .Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryId = p.CategoryId,
            CategoryName = p.Category != null ? p.Category.Name : null,
            CreatedAt = p.CreatedAt
        }).ToListAsync();

    return Results.Ok(products);
});

// GET: Lấy sản phẩm theo Id
productGroup.MapGet("/{id:int}", async (int id, AppDbContext db) =>
{
    var product = await db.Products
        .Include(p => p.Category)
        .Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryId = p.CategoryId,
            CategoryName = p.Category != null ? p.Category.Name : null,
            CreatedAt = p.CreatedAt
        })
        .FirstOrDefaultAsync(p => p.Id == id);

    return product is null ? Results.NotFound() : Results.Ok(product);
});

// POST: Tạo mới sản phẩm
productGroup.MapPost("/", async (CreateProductDto dto, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name))
        return Results.BadRequest("Product name is required.");

    if (!await db.Categories.AnyAsync(c => c.Id == dto.CategoryId))
        return Results.BadRequest($"Category with Id {dto.CategoryId} not found.");

    var product = new Product
    {
        Name = dto.Name,
        Price = dto.Price,
        Stock = dto.Stock,
        CategoryId = dto.CategoryId
    };

    db.Products.Add(product);
    await db.SaveChangesAsync();

    return Results.Created($"/api/products/{product.Id}", product);
});

// PUT: Cập nhật sản phẩm
productGroup.MapPut("/{id:int}", async (int id, UpdateProductDto dto, AppDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    if (product == null) return Results.NotFound();

    if (dto.CategoryId.HasValue && !await db.Categories.AnyAsync(c => c.Id == dto.CategoryId.Value))
        return Results.BadRequest($"Category with Id {dto.CategoryId} not found.");

    product.Name = dto.Name ?? product.Name;
    product.Price = dto.Price ?? product.Price;
    product.Stock = dto.Stock ?? product.Stock;
    product.CategoryId = dto.CategoryId ?? product.CategoryId;

    await db.SaveChangesAsync();
    return Results.Ok(product);
});

// DELETE: Xóa sản phẩm
productGroup.MapDelete("/{id:int}", async (int id, AppDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    if (product == null) return Results.NotFound();

    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.Ok($"Product {id} deleted successfully.");
});

app.Run();
