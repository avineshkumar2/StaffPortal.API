using StaffPortal.API.Models;
using System.Collections.Generic;
//using UniversityPortal.API.Models;

namespace StaffPortal.API.Services
{
    public interface IGenderService
    {
        IEnumerable<Gender> GetAllGenders();
        Gender GetGenderById(int id);
    }
}
