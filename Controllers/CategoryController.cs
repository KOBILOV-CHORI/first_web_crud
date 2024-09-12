using FirstCrudinWeb.Models;
using FirstCrudinWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstCrudinWeb.Controllers;

[Route("Category")]
[ApiController]

public class CategoryController:ControllerBase
{
    private readonly ICategoryService _categoryService = new CategoryService();
    [HttpGet]
    public IEnumerable<Category> GetAllCategories()
    {
        return _categoryService.GetAllCategories();
    }

    [HttpGet("{id}")]
    public Category? GetCategoryById(int id)
    {
        return _categoryService.GetCategoryById(id);
    }

    [HttpPost]
    public bool CreateCategory(Category category)
    {
        return _categoryService.AddCategory(category);
    }

    [HttpPut]
    public bool UpdateCategory(Category category)
    {
        return _categoryService.UpdateCategory(category);
    }

    [HttpDelete]
    public bool DeleteCategory(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
}