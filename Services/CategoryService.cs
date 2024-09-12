using Dapper;
using FirstCrudinWeb.Models;
using Npgsql;

namespace FirstCrudinWeb.Services;

public class CategoryService : ICategoryService
{
    public IEnumerable<Category> GetAllCategories()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Category>(SqlCommands.GetAllCategories);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Category? GetCategoryById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Category>(SqlCommands.GetCategoryById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddCategory(Category category)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddCategory, category) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateCategory(Category category)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateCategory, category) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteCategory(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteCategory, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommands
{
    public const string ConnectionString =
        "Server=localhost;Port=5432;Database=web_db;User Id=postgres;Password=01062007;";

    public const string GetAllCategories = "SELECT * FROM categories";
    public const string GetCategoryById = "SELECT * FROM categories WHERE id = @id";
    public const string AddCategory = "INSERT INTO categories (name) VALUES (@name)";
    public const string UpdateCategory = "UPDATE categories SET name = @name WHERE id = @id";
    public const string DeleteCategory = "DELETE FROM categories WHERE id = @id";
}