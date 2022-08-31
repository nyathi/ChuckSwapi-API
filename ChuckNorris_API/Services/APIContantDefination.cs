using RestSharp;

namespace ChuckNorris_API.Services
{
    public class APIContantDefination : IAPIContantDefination
    {

        public string? APIContantData(string url)
        {
            using (var client = new RestClient(url))
            {
                var response = client.Execute(new RestRequest());

                return response.IsSuccessful ? response.Content : null;
            };
           
        }
    }
}
