using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversityMain.Interface;
using UniversityMain.Models;
using UniversityMain.Repository;

namespace UniversityMain.ControolersApi
{
    [RoutePrefix("api/University")]
    public class UniversityController : ApiController
    {
        private readonly IUniversity _universityRepo;

        public UniversityController()
        {
            _universityRepo = new UniversityRepository();
        }

        [Route(nameof(GetAll))]
        [HttpGet]
        public ICollection<UniversityDto> GetAll()
        {
            var universityList = _universityRepo.GetAllUniversity();

            return universityList.ToList();
        }
    }
}
