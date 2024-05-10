using System;
using System.Collections.Generic;
using StaffPortal.API.Data;
using StaffPortal.API.Models;

namespace StaffPortal.API.Services
{
    public class GenderService : IGenderService
    {
        private readonly ApplicationDbContext _context;

        public GenderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            // Implement logic to fetch all genders from the database
            return _context.Genders;
        }

        public Gender GetGenderById(int id)
        {
            // Implement logic to fetch gender by ID from the database
            var gender = _context.Genders.Find(id);
            if (gender == null)
            {
                throw new InvalidOperationException($"Gender with ID {id} not found.");
            }
            return gender;
        }

    }
}
