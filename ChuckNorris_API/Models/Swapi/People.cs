namespace ChuckNorris_API.Models.Swapi
{
    public class People
    {
        private string _origin = "Star Wars API";
        public string Origin { get => _origin; set => _origin = value; }
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        public Person[] Results { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_Color { get; set; }
        public string Skin_Color { get; set; }
        public string Eye_Color { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string[] Films { get; set; }
        public string[] Species { get; set; }
        public string[] Vehicles { get; set; }
        public string[] Starships { get; set; }
    }
}
