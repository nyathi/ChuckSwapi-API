using RestSharp;

namespace ChuckNorris_API.Services
{
    public class APIContantDefination : IAPIContantDefination
    {

        public string? APIContantData(string url)
        {

            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                return null;
            }

            return response.Content;

        }
    }
}
