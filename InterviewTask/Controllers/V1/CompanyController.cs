using Asp.Versioning;
using InterviewTask.Domain;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("create")]
        public IActionResult CreateCompany(CompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_companyService.CreateCompany(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_companyService.GetAll());
        }

        [HttpPut("update")]
        public IActionResult UpdateCompany(CompanyModel model)
        {
            if(model.Id == 0)
            {
                return BadRequest("'Id' is required field");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_companyService.UpdateCompany(model));
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
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                _companyService.DeleteCompany(id);
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
