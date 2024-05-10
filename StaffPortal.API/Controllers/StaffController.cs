using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffPortal.API.Data;
using StaffPortal.API.Models;
using StaffPortal.API.Services;

namespace StaffPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly ApplicationDbContext _context;

        public StaffController(IStaffService staffService, ApplicationDbContext context)
        {
            _staffService = staffService;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Staff>> GetAllStaff()
        {
            var staff = _staffService.GetAllStaff();
            return Ok(staff);
        }

        [HttpGet("{id}")]
        public ActionResult<Staff> GetStaffById(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpPost]
        public ActionResult<Staff> CreateStaff(Staff staff)
        {
            // Retrieve qualification level from the database using qualificationId
            var qualification = _context.Qualifications.FirstOrDefault(q => q.Id == staff.QualificationId);
            if (qualification == null)
            {
                return BadRequest("Qualification not found");
            }

            // Calculate salary using provided formula
           // decimal salary = (qualification.Level / 10) * (staff.YearsOfWorkExperience / 5) * 100000;
            decimal salary = (qualification.Level / 10m) * (staff.YearsOfWorkExperience / 5m) * 100000m;


            // Assign calculated salary to the staff object
            staff.Salary = salary;

            // Create staff record
            var createdStaff = _staffService.CreateStaff(staff);

            // Return the created staff object with the calculated salary
            return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.Id }, createdStaff);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }

            _staffService.UpdateStaff(id, staff);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            _staffService.DeleteStaff(id);
            return NoContent();
        }

    }
}
