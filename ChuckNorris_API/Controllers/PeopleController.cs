using ChuckNorris_API.Models.Swapi;
using ChuckNorris_API.Services.chuck;
using ChuckNorris_API.Services.Swapi;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChuckNorris_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        #region Properties
        private IPeopleService _people { get;}
    #endregion

    #region Constructor
    public PeopleController(IPeopleService people)
    {
        _people = people;
    }
        #endregion
        // GET: api/<PeopleController>
    [HttpGet, Route("/swapi/people")]
    public People? Get()
    {
        return _people.List("https://swapi.dev/api/people/");
    }
    }
}
