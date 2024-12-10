namespace MyLibrary.Shared
{
    public partial class Person
    {
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        public string Greeting => $"{Name} says 'Hello!' ";

        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        /* 💡Although you have not 
        manually created a field to 
        store the person's favorite ice cream,
        it is there, automatically created by the compiler for you.
        */
        public string FavoriteIceCream { get; set; } // auto-syntax

        /**
        Sometimes, you need more control over what happens when a property is set. In this
        scenario, you must use a more detailed syntax and manually create a private field to
        store the value for the property.
        */
        private string favoritePrimaryColor;
        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException(
                          $"{value} is not a primary color. " +
                          "Choose from: red, green, blue.");
                }
            }
        }

        // 💡using indexers
        public Person this[int index]
        {
            get
            {
                return Children[index]; // pass on to the List<T> indexer
            }
            set
            {
                Children[index] = value;
            }
        }
    }
}