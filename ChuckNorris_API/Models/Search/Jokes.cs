namespace ChuckNorris_API.Models.Search
{
    public class Jokes
    {
        private string _origin = "Chuck Norris";
        public string Origin { get => _origin; set => _origin = value; }
        public int Total { get; set; }
        public Joke[] result { get; set; }
       
    }

    public class Joke
    {
        public string[] Categories { get; set; }
        public string Created_At { get; set; }
        public string Icon_Url { get; set; }
        public string Id { get; set; }
        public string Updated_at { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
