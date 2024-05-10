using StaffPortal.API.Models;
using StaffPortal.API.Services;
using System;
using System.Collections.Generic;
using StaffPortal.API.Data;
//using UniversityPortal.API.Models;

namespace StaffPortal.API.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly ApplicationDbContext _context;

        public QualificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Qualification> GetAllQualifications()
        {
            // Implement logic to fetch all qualifications from the database
            return _context.Qualifications;
        }

        public Qualification GetQualificationById(int id)
        {
            // Implement logic to fetch qualification by ID from the database
            var qualification = _context.Qualifications.Find(id);
            if (qualification == null)
            {
                throw new InvalidOperationException($"Qualification with ID {id} not found.");
            }
            return qualification;
        }
    }
}
