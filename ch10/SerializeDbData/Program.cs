
using static System.Console;
using WorkingWithEFCore.AutoGen;
using Serializer.Shared;

ConfigureConsole();
WriteLine("Hello");
Category[] categories = GetCategories();

SectionTitle("Categories to JSON");
Serializer.Shared.Serializer.CategoriesToJSON(categories);