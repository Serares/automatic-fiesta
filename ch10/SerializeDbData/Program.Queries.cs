
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use CollectionEntry.
using Microsoft.EntityFrameworkCore; // To use Include method.
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkingWithEFCore.AutoGen;

partial class Program
{
    private static Category[] GetCategories()
    {
        using NorthwindDb db = new();
        SectionTitle("Categories and how many products they have");
        // A query to get all categories and their related products.
        IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

        // ❗the order of the clauses here is important
        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return Array.Empty<Category>();
        }
        // foreach (Category c in categories)
        // {
        //     WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        // }

        return [.. categories];
    }
}
