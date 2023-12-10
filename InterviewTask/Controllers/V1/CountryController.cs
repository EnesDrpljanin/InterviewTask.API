using Asp.Versioning;
using InterviewTask.Domain;
using InterviewTask.Service;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("create")]
        public IActionResult CreateCountry(CountryModel countryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_countryService.CreateCountry(countryModel));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_countryService.GetAll());
        }

        [HttpPut("update")]
        public IActionResult UpdateCountry(CountryModel model)
        {
            if (model.Id == 0)
            {
                return BadRequest("'Id' is required field");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_countryService.UpdateCountry(model));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            try
            {
                _countryService.DeleteCountry(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
