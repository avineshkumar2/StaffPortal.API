using System;
using System.Collections.Generic;
using System.Linq;
using StaffPortal.API.Data;
using StaffPortal.API.Models;

namespace StaffPortal.API.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _context;

        public StaffService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return _context.Staff.ToList();
        }

        public Staff GetStaffById(int id)
        {
            return _context.Staff.FirstOrDefault(s => s.Id == id);
        }


        public Staff GetStaffByEmployeeNumber(string empNo)
        {
            return _context.Staff.Where(x=>x.EmployeeNumber == empNo.Trim()).FirstOrDefault();
        }


        public Staff CreateStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            _context.Staff.Add(staff);
            _context.SaveChanges();
            return staff;
        }

        public Staff UpdateStaff(int id, Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            var existingStaff = _context.Staff.Find(id);
            if (existingStaff == null)
            {
                throw new InvalidOperationException($"Staff with ID {id} not found.");
            }

            existingStaff.FirstName = staff.FirstName;
            existingStaff.LastName = staff.LastName;
            existingStaff.DateOfBirth = staff.DateOfBirth;

            _context.SaveChanges();
            return existingStaff;
        }

        public void DeleteStaff(int id)
        {
            var staffToDelete = _context.Staff.Find(id);
            if (staffToDelete == null)
            {
                throw new InvalidOperationException($"Staff with ID {id} not found.");
            }

            _context.Staff.Remove(staffToDelete);
            _context.SaveChanges();
        }

    }
}
