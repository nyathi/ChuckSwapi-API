using ChuckNorris_API.Models.chuck;
using ChuckNorris_API.Models.Swapi;
using Newtonsoft.Json;
using RestSharp;

namespace ChuckNorris_API.Services.Swapi
{
    public class PeopleService : IPeopleService
    {
        #region Constructor
        #endregion

        #region Swapi People Service 
        public People? List()
        {
            try
            {
                return JsonConvert.DeserializeObject<People?>(APIContant);
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        #endregion

        #region Private Actions
        private string? APIContant
        {
            get
            {
                var client = new RestClient("https://swapi.dev/api/people/");
                var request = new RestRequest();
                var response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    return null;
                }

                return response.Content;
            }
        }
        #endregion
    }
}

