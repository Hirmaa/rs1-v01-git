using Microsoft.AspNetCore.Mvc;
using RS1Vjezbe2API.Dtos;
using RS1Vjezbe2API.Data;
using RS1Vjezbe2API.Models;
using Microsoft.EntityFrameworkCore;

namespace RS1Vjezbe2API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(AppDbContext db) : Controller
    {
        [HttpGet]
        public async Task<List<StudentResponse>> GetAll(CancellationToken ct)
        {
            
            IQueryable<Student> upit = db.Studenti;
            return await upit.OrderBy(x => x.Prezime).ThenBy(x => x.Ime).Select(x => new StudentResponse
            {
                Id = x.Id,
                ImePrezime = x.Ime + " " + x.Prezime,
                BrojIndeksa = x.BrojIndeksa,
                DatumRodjenja = x.DatumRodjenja,
                Smjer = x.Smjer != null ? x.Smjer.Naziv : null
            }).ToListAsync();

            //List<Student> studenti = await db.Studenti.ToListAsync(ct);
            //return studenti.Select(s => Mapiraj(s)).ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponse>> GetById(int id, CancellationToken ct)
        {
            Student? student = await db.Studenti.FirstOrDefaultAsync(c => c.Id == id, ct);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(Mapiraj(student));
        }
        [HttpPost]
        public async Task<ActionResult<StudentResponse>> Dodaj(StudentDodajRequest request, CancellationToken ct)
        {
            Student student=new Student()
            {
                Ime=request.Ime,
                Prezime=request.Prezime,
                BrojIndeksa=request.BrojIndeksa,
                DatumRodjenja = request.DatumRodjenja,
                DatumKreiranja = DateTime.Now
            };
            db.Studenti.Add(student);
            await db.SaveChangesAsync(ct);
            return Ok(Mapiraj(student));
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
