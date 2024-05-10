using StaffPortal.API.Models;
using System.Collections.Generic;
//using UniversityPortal.API.Models;

namespace StaffPortal.API.Services
{
    public interface IStaffService
    {
        IEnumerable<Staff> GetAllStaff();
        Staff GetStaffById(int id);

        Staff GetStaffByEmployeeNumber(string empNo);
        Staff CreateStaff(Staff staff);
        Staff UpdateStaff(int id, Staff staff);
        void DeleteStaff(int id);
    }
}
