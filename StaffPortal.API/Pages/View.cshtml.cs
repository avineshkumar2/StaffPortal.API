using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffPortal.API.Models;
using StaffPortal.API.Services;

namespace StaffPortal.API.Pages
{
    public class ViewModel : PageModel
    {
        private readonly IStaffService _staffService;

        public ViewModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public Staff Staff { get; set; }
        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        public void OnGet(string employeeNumber, int val)
        {
            if (!string.IsNullOrEmpty(employeeNumber))
            {
                Staff = _staffService.GetStaffByEmployeeNumber(employeeNumber);
                if(Staff == null)
                {
                   ErrorMessage = "Record not found.";
                }
                else
                {
                    if(val == 1)
                    {
                        SuccessMessage = "Record updated successfully";
                    }
                    
                }
            }
        }

        public IActionResult OnPost(string employeeNumber, string firstName, string lastName, DateTime dateOfBirth)
        {
            var staff = _staffService.GetStaffByEmployeeNumber(employeeNumber);

            if (staff == null)
            {
                ErrorMessage = "Record not found.";
                return Page();
            }

            staff.FirstName = firstName;
            staff.LastName = lastName;
            staff.DateOfBirth = dateOfBirth;

         //   _staffService.UpdateStaff(staff);
            _staffService.UpdateStaff(staff.Id, staff);
            int val = 1;
            return RedirectToPage(new { employeeNumber, val});
        }

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var staff = _staffService.GetStaffByEmployeeNumber(Staff.EmployeeNumber);

        //    if (staff == null)
        //    {
        //        ViewData["ErrorMessage"] = "Record not found.";
        //        return Page();
        //    }

        //    staff.FirstName = Staff.FirstName;
        //    staff.LastName = Staff.LastName;
        //    staff.DateOfBirth = Staff.DateOfBirth;

        //    _staffService.UpdateStaff(staff.Id, staff);

        //    return RedirectToPage(new { employeeNumber = Staff.EmployeeNumber });
        //}
    }
}
