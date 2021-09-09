using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMain.Models
{
    public class UniversityDto
    {
        public string UniversityName { get; set; }
        public string UniversityDescription { get; set; }
        public string Country { get; set; }
        public int? MinimumGpa { get; set; }
        public int? MinimumGreScore { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }

    }
}