using Northwind.EntityModels;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

// configure trace to log db logs
Trace.Listeners.Add(
    new TextWriterTraceListener(
        File.CreateText(Path.Combine(Environment.CurrentDirectory, "db_logs.txt"))
        ));
Trace.AutoFlush = true;

// using NorthwindDb db = new();
// WriteLine("Provider {0}", arg0: db.Database.ProviderName);
ConfigureConsole();
// QueryingCategories();
// FilteredIncludes();
// QueryingProducts();
// GettingOneProduct();
// QueryingWithLike();
var resultAdd = AddProduct(categoryId: 6,
productName: "Bob's Burgers", price: 500M, stock: 72);
if (resultAdd.affected == 1)
{   
    /* 💡
    State: Added, ProductId: 0
State: Unchanged, ProductId: 78
Add product successful with ID: 78.
    📝
    When the new product is first created in memory and tracked by the EF Core change
tracker, it has a state of Added and its ID is 0. After the call to SaveChanges, it has a state
of Unchanged and its ID is 78, the value assigned by the database.
*/
    WriteLine($"Add product successful with ID: {resultAdd.productId}.");
}
ListProducts(productIdsToHighlight: new[] { resultAdd.productId });