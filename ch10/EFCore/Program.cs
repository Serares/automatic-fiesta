using Northwind.EntityModels;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

// configure trace to log db logs
Trace.Listeners.Add(
    new TextWriterTraceListener(
        File.CreateText(Path.Combine(Environment.CurrentDirectory, "lazy_loading_queries_db_logs.txt"))
        ));
Trace.AutoFlush = true;

// using NorthwindDb db = new();
// WriteLine("Provider {0}", arg0: db.Database.ProviderName);
ConfigureConsole();
QueryingCategories();
// FilteredIncludes();
// QueryingProducts();
// GettingOneProduct();
// QueryingWithLike();