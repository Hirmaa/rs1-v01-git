using Microsoft.AspNetCore.Mvc;
using RS1Vjezbe2API.Dtos;
using RS1Vjezbe2API.Data;
using RS1Vjezbe2API.Models;

namespace RS1Vjezbe2API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(StudentStorage studentStorage) : Controller
    {
        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            List<Student> studenti = studentStorage.GetAll();
            return studenti.Select(s => Mapiraj(s)).ToList();
        }

        private static StudentResponse Mapiraj(Student s) {
            return new StudentResponse() { 
            Id=s.Id,
            ImePrezime=$"{s.Ime} {s.Prezime}",
            BrojIndeksa = s.BrojIndeksa,
            DatumRodjenja=s.DatumRodjenja,
            };
        }
    }
}
