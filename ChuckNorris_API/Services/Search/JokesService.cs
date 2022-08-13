using ChuckNorris_API.Models.Search;
using ChuckNorris_API.Models.Swapi;
using Newtonsoft.Json;

namespace ChuckNorris_API.Services.Search
{
    public class JokesService : IJokesService
    {
        #region Properties
        private IAPIContantDefination _PIContantDefination { get; }
        #endregion

        #region Constructor
        public JokesService(IAPIContantDefination aPIContantDefination)
        {
            _PIContantDefination = aPIContantDefination;
        }
        #endregion

        #region Service 
        public Jokes? GetJoke(string url)
        {
            try
            {
                return JsonConvert.DeserializeObject<Jokes?>(_PIContantDefination.APIContantData(url));
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public People? GetProfile(string url)
        {
            try
            {

                return JsonConvert.DeserializeObject<People?>(_PIContantDefination.APIContantData(url));
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        #endregion

        #region Private Actions
       
        #endregion
    }
}
