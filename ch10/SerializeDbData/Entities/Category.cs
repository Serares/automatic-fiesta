using System;
using System.Xml.Serialization;

namespace Entities.Shared;

public partial class CategoryEntity
{
    [XmlAttribute("categoryId")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; } = null!;

    [XmlAttribute("description")]
    public string? Description { get; set; }

    [XmlAttribute("picture")]
    public byte[]? Picture { get; set; }

    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
