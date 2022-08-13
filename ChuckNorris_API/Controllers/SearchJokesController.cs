using ChuckNorris_API.Models.Search;
using ChuckNorris_API.Models.Swapi;
using ChuckNorris_API.Services.Search;
using ChuckNorris_API.Warning;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChuckNorris_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchJokesController : ControllerBase
    {
        #region Properties
        private IJokesService _jokes { get; }
        public List<Warning.Warning> Warnings { get; } = new List<Warning.Warning>();
        #endregion

        #region Constructor
        public SearchJokesController(IJokesService jokes)
        {
            _jokes = jokes;
        }
        #endregion

        /// <summary>
        /// Retrieves profile and jokes Information
        /// </summary>
        /// <param name="input">
        /// Jokes: Joke
        /// Profile: Person
        /// </param>
        /// <returns></returns>
        [HttpPost("/search")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(getSearchDetail))]
        public async Task<IActionResult?> GetAsync([FromBody] getSearchDetail input)
        {
            if (input == null) return NullInput();


            if (string.IsNullOrEmpty(input.joke))
            {
                return NullJoke();
            }

            if (string.IsNullOrEmpty(input.profile))
            {
                return NullProfile();
            }

            var profile = _jokes.GetProfile($"https://swapi.dev/api/people/?search={input.profile}");
            var joke= _jokes.GetJoke($"https://api.chucknorris.io/jokes/search?query={input.joke}");
           // await Task.WaitAll(profile, joke).ConfigureAwait(false);
            var searchResult = new Search()
            {
                Joke = joke,
                Profile = profile
            };
            return Ok(searchResult);

           
        }

        [HttpGet("/searchJoke")]
        public async Task<IActionResult?> SearchJoke([System.Web.Http.FromUri] string input)
        {
            if (input == null) return NullInput();

            var joke = _jokes.GetJoke($"https://api.chucknorris.io/jokes/search?query={input}");

            return Ok(joke);

        }

        [HttpGet("/searchPeople")]
        public async Task<IActionResult?> SearchPeople([System.Web.Http.FromUri] string input)
        {
            if (input == null) return NullInput();

            var profile = _jokes.GetProfile($"https://swapi.dev/api/people/?search={input}");

            return Ok(profile);

        }

        #region Private Actions
        private dynamic NullInput()
        {
            Warnings.Add(new Warning.Warning(WarningCode.NullInput));
            return null;
        }
        private dynamic NullJoke()
        {
            Warnings.Add(new Warning.Warning(WarningCode.NullJoke));
            return null;
        }
        private dynamic NullProfile()
        {
            Warnings.Add(new Warning.Warning(WarningCode.NullProfile));
            return null;
        }
        #endregion
    }

    #region Private Classess
    public class Search
    {
        public Jokes? Joke { get; set; }
        public People? Profile { get; set; }
    }

    public class getSearchDetail
    {

        public string profile { get; set; }

        public string joke { get; set; }

    }
    #endregion
}
