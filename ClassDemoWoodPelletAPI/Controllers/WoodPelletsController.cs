using ClassDemoWoodPelletLib.model;
using ClassDemoWoodPelletLib.repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassDemoWoodPelletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletsController : ControllerBase
    {
        private readonly WoodPelletRepository _repo;
        private const string BaseURI = "api/WoodPellets/";

        public WoodPelletsController(WoodPelletRepository repo)
        {
            _repo = repo;
        }



        // GET: api/<WoodPelletsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            List<WoodPellet> liste = _repo.GetAll();

            if (liste.Count == 0)
            {
                return NoContent();
            }

            return Ok(liste);
        }

        // GET api/<WoodPelletsController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<WoodPelletsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] WoodPellet value)
        {
            try
            {
                _repo.Add(value);
                return Created(BaseURI + value.Id, value);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

        }

        // PUT api/<WoodPelletsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] WoodPellet value)
        {
            try
            {
                _repo.Update(id, value);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }
    }
}
