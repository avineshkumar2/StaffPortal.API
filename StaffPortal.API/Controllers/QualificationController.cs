using Microsoft.AspNetCore.Mvc;
using StaffPortal.API.Models;
using StaffPortal.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;

        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Qualification>> GetAllQualifications()
        {
            var qualifications = _qualificationService.GetAllQualifications();
            return Ok(qualifications);
        }

        [HttpGet("{id}")]
        public ActionResult<Qualification> GetQualificationById(int id)
        {
            var qualification = _qualificationService.GetQualificationById(id);
            if (qualification == null)
            {
                return NotFound();
            }
            return Ok(qualification);
        }
    }
}
