using WorkingWithEFCore.AutoGen;
using Entities.Shared;
using FastJson = System.Text.Json.JsonSerializer;
using System.Text.Json;

namespace Serializer.Shared;

public static class Serializer
{
    public static void CategoriesToJSON(Category[] list)
    {
        // transform category model to category entity (serializable)
        List<CategoryEntity> entities = new();

        foreach (Category cat in list)
        {
            CategoryEntity nc = new()
            {
                Id = cat.CategoryId,
                Name = cat.CategoryName,
                Description = cat.Description,
                Products = cat.Products.Select(p => new ProductEntity
                {
                    Id = p.ProductId,
                    Discontinued = p.Discontinued,
                    UnitPrice = p.UnitPrice,
                    QuantityPerUnit = p.QuantityPerUnit,
                }).ToList() ?? [] // Ensure no null assignments,
            };

            entities.Add(nc);
        }
        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        // wrapper of categories
        var wrapper = new
        {
            categories = entities
        };

        // serialize to JSON
        string jsonPath = Combine(CurrentDirectory, "categories.json");

        using Stream jsonStream = File.Create(jsonPath);
        FastJson.Serialize(jsonStream, wrapper, options);
    }
}