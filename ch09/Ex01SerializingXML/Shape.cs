namespace MyLibrary.Shared;
using System.Xml.Serialization; // To use [XmlAttribute].
[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Rectangle))]
public abstract class Shape
{
    public Shape() { }
    [XmlAttribute("color")]
    public string? Color { get; set; }
    public abstract string? Area { get; } // 💡 can make this abstract in an abstract class to enforce subclasses to implement this
}

public class Rectangle : Shape
{
    public Rectangle() { }
    [XmlAttribute("height")]
    public decimal Height { get; set; }

    [XmlAttribute("width")]
    public decimal Width { get; set; }
    public override string Area
    {
        get
        {
            decimal area = Height * Width;
            return area.ToString();
        }
    }
}

public class Circle : Shape
{
    public Circle() { }
    [XmlAttribute("radius")]
    public decimal Radius { get; set; }

    public override string Area
    {
        get
        {
            double r = (double)Radius;
            double area = Math.PI * Math.Pow(r, 2);

            return area.ToString();
        }
    }
}