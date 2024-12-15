
using System.Xml.Serialization;

namespace Entities.Shared;

public class ProductEntity
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("pName")]
    public string Name { get; set; } = null!;

    [XmlAttribute("supplierId")]
    public int? SupplierId { get; set; }

    [XmlAttribute("categoryId")]
    public int? CategoryId { get; set; }

    [XmlAttribute("quantity")]
    public string? QuantityPerUnit { get; set; }

    [XmlAttribute("unitPrice")]
    public double? UnitPrice { get; set; }

    [XmlAttribute("stock")]
    public short? UnitsInStock { get; set; }

    [XmlAttribute("unitsPerOrder")]
    public short? UnitsOnOrder { get; set; }

    [XmlAttribute("reorderLevel")]
    public short? ReorderLevel { get; set; }

    [XmlAttribute("discontinued")]
    public bool Discontinued { get; set; }

    public CategoryEntity? Category { get; set; }
}
