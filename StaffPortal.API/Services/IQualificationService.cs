using StaffPortal.API.Models;
using System.Collections.Generic;
//using UniversityPortal.API.Models;

namespace StaffPortal.API.Services
{
    public interface IQualificationService
    {
        IEnumerable<Qualification> GetAllQualifications();
        Qualification GetQualificationById(int id);
    }
}
