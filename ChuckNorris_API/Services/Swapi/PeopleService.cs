using ChuckNorris_API.Models.chuck;
using ChuckNorris_API.Models.Swapi;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace ChuckNorris_API.Services.Swapi
{
    public class PeopleService : IPeopleService
    {

        #region Properties
        private IAPIContantDefination _PIContantDefination { get; }
        #endregion

        #region Constructor
        public PeopleService(IAPIContantDefination aPIContantDefination)
        {
            _PIContantDefination=aPIContantDefination;
        }
        #endregion

        #region Swapi People Service 
        public People? List(string url)
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

