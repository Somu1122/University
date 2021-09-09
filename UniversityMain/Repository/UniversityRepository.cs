using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityMain.Interface;
using UniversityMain.Models;

namespace UniversityMain.Repository
{
    public class UniversityRepository : IUniversity
    {
        private readonly UniversityEntities _context;

        //Endpoint_Drive_23Entities context;

        public UniversityRepository()
        {
            _context = new UniversityEntities();

        }

        public ICollection<UniversityDto> GetAllUniversity()
        {
            var universityList =  (from u in _context.Universities
                join c in _context.Courses on u.Id equals c.University_id
                select new UniversityDto
                {
                    Country = u.Country,
                    CourseName = c.Name,
                    UniversityName = u.Name,
                    UniversityDescription = u.Description,
                    MinimumGpa = u.Minimum_gpa,
                    MinimumGreScore = u.Minimum_gre_score,
                    TeacherName = c.Teacher_name
                }).ToList();

            return universityList;
        }
    }
}