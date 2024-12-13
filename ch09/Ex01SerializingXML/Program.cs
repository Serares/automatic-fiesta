using System.Xml.Serialization; // To use XmlSerializer.


using MyLibrary.Shared;

List<Shape> listOfShapes = new() {
    new Circle {Color="Red", Radius = 19.3M},
    new Rectangle {Color="Blue", Height= 12.3M, Width = 18.9M},
    new Circle {Color="Blue", Radius = 8.2M}
};


XmlSerializer xs = new(type: listOfShapes.GetType());

string pathToFile = Combine(CurrentDirectory, "shapes.xml");

WriteLine("Serializing to XML {0}",
arg0: pathToFile
);
using (FileStream stream = File.Create(pathToFile))
{
    xs.Serialize(stream, listOfShapes);
}

WriteLine("Desirialize XML {0}",
arg0: pathToFile
);

using (FileStream xmlLoad = File.Open(pathToFile, FileMode.Open))
{
    List<Shape>? list = xs.Deserialize(xmlLoad) as List<Shape>;


    if (list is not null)
    {
        foreach (Shape sh in list)
        {
            WriteLine("Shape: {0} \n color {1} \n Area: {2}",
            arg0: sh.GetType(),
            arg1: sh.Color,
            arg2: sh.Area
            );
        }
    }
}
