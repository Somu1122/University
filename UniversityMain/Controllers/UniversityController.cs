using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UniversityMain.Models;

namespace UniversityMain.Controllers
{
    public class UniversityController : Controller
    {
        // GET: University
        public async Task<ActionResult> Index(string option, string search)
        {
            //Hosted web API REST Service base url


            ICollection<UniversityDto> universityDtos = new List<UniversityDto>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                var Baseurl = "https://localhost:44371/";
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/University/GetAll");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var universityResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    universityDtos = JsonConvert.DeserializeObject<List<UniversityDto>>(universityResponse);
                }
                //returning the employee list to view
                if (option == "GPA")
                {
                    //Index action method will return a view with a student records based on what a user specify the value in textbox  
                    var list = universityDtos.AsEnumerable().Where(gpa => gpa.MinimumGpa >= Convert.ToInt32(search) || search == null).ToList();

                    return View(list);

                }

                if (option == "GRE")
                {
                    var list = universityDtos.AsEnumerable().Where(gpa => gpa.MinimumGreScore >= Convert.ToInt32(search) || search == null).ToList();

                    return View(list);
                }
                if (option == "Country")
                {
                    var list = universityDtos.AsEnumerable().Where(gpa => gpa.Country == search || search == null).ToList();

                    return View(list);
                }
                if(option== "CourseName")
                {
                    var list = universityDtos.AsEnumerable().Where(gpa => gpa.CourseName.ToLower().ToString().Contains(search.ToLower()) || search == null).ToList();

                    return View(list);
                }
                return View(universityDtos);
            }
        }
    }
}