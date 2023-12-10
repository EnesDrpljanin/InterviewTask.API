using Asp.Versioning;
using InterviewTask.Domain.ContactModels;
using InterviewTask.Service;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("create")]
        public IActionResult CreateContact(ContactCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_contactService.CreateContact(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_contactService.GetAll());
        }

        [HttpPut("update")]
        public IActionResult UpdateContact([FromBody]ContactUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_contactService.UpdateContact(model));
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
        public IActionResult DeleteContact(int id)
        {
            try
            {
                _contactService.DeleteContact(id);
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

        [HttpGet("all-with-country-and-company")]
        public IActionResult GetAllWithCountryAndCompany()
        {
            return Ok(_contactService.GetContactsWithCompanyAndCountry());
        }


        [HttpGet("filter")]
        public IActionResult FilterContacts([FromQuery] int? countryId, [FromQuery] int? companyId)
        {
            return Ok(_contactService.FilterContacts(countryId, companyId));
        }

    }
}
