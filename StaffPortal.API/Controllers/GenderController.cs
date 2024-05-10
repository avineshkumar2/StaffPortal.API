using Microsoft.AspNetCore.Mvc;
using StaffPortal.API.Models;
using StaffPortal.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Gender>> GetAllGenders()
        {
            var genders = _genderService.GetAllGenders();
            return Ok(genders);
        }

        [HttpGet("{id}")]
        public ActionResult<Gender> GetGenderById(int id)
        {
            var gender = _genderService.GetGenderById(id);
            if (gender == null)
            {
                return NotFound();
            }
            return Ok(gender);
        }
    }
}
