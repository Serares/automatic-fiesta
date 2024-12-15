using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
namespace Northwind.EntityModels;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    // Defines a navigation property for related rows.
    /*
    The two properties that relate the two entities, 
    Category.Products and Product.Category, are both marked as virtual. 
    This allows EF Core to inherit and override 
    the properties to provide extra features,
    such as lazy loading.
    */
    public virtual ICollection<Product> Products { get; set; }
    // To enable developers to add products to a Category, we must
    // initialize the navigation property to an empty collection.
    // This also avoids an exception if we get a member like Count.
    = new HashSet<Product>();

}