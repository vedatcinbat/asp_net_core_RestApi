using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{

    [ApiController]
    public class HomeController : ControllerBase
    {
        List<Student> Allstudents = new List<Student>() {
                new Student() {Id = 1, StudentFirstName = "Vedat", StudentLastName = "Cinbat", StudentGrade = "2nd Grade"},
                new Student() {Id = 2, StudentFirstName = "John", StudentLastName = "Stones", StudentGrade = "1st Grade"},
                new Student() {Id = 3, StudentFirstName = "Natalie", StudentLastName = "Kalie", StudentGrade = "3rd Grade"},
            };
        [HttpGet]
        [Route("api/home")]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP.NET Core Web API",
            };
            return Ok(result);
        }
        [HttpGet]
        [Route("api/message")]
        public String helloUser()
        {
            return "Hello User";
        }

        [HttpGet]
        [Route("api/students")]
        public IActionResult studentsInfo()
        {

            return Ok(Allstudents);
        }
        [HttpGet]
        [Route("api/students/{id}")]
        public IActionResult studentsInfo(int id)
        {
            var student = Allstudents.Find(i => i.Id == id);
            return Ok(student);
        }

        [HttpPost]
        [Route("api/students")]
        public IActionResult addStudent(Student student)
        {
            Allstudents.Add(student);
            return Ok(Allstudents);
        }

        [HttpDelete]
        [Route("api/students/{id}")]
        public IActionResult delStudent(int id)
        {
            bool idExists = Allstudents.Any(item => item.Id == id);

            if (idExists)
            {
                var student = Allstudents.Find(i => i.Id == id);
                Allstudents.Remove(student);
                return Ok(Allstudents);
            }
            else
            {
                return BadRequest("There is no matched id in that array !");
            }


        }

    }
}