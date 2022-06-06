using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationService _locationService;
        ILogger<LocationController> _logger;
        public LocationController(ILocationService locationService,ILogger<LocationController> logger=null)
        {
            _locationService = locationService;
            _logger= logger;    
        }
        // GET: api/<PatientController>
        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetAsync()
        {
           _logger.LogInformation("get all!!!!");
           
            return await _locationService.GetAllAsync();
        }


        [HttpGet("city/{city}")]
        public async Task<ActionResult<List<Location>>> GetAsync(string city)
        {
            return await _locationService.GetAllByCityAsync(city);
        }
        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Location>>> GetAsync(int id)
        {
            return await _locationService.GetAsync(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task PostAsync([FromBody] Location location)
        {
            if(location== null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            try
            {
                await _locationService.PostAsync(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        // PUT api/<PatientController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PatientController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
