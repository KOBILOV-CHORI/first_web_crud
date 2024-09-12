using FirstCrudinWeb.Models;

namespace FirstCrudinWeb.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories();
    Category? GetCategoryById(int id);
    bool AddCategory(Category category);
    bool UpdateCategory(Category category);
    bool DeleteCategory(int id);
}