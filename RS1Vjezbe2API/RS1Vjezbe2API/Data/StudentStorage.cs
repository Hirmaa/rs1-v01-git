using RS1Vjezbe2API.Models;
namespace RS1Vjezbe2API.Data
{
    public class StudentStorage
    {
        private readonly List<Student> _students = [];
        private int _sljedeciId = 1;
        public StudentStorage()
        {
            Dodaj(new Student()
            {
                Ime = "Mahir",
                Prezime = "Mustafic",
                BrojIndeksa = "IB260001",
                DatumRodjenja = new DateOnly(2000, 1, 1)
            });

            Dodaj(new Student()
            {
                Ime = "Elina",
                Prezime = "Mazafakovna",
                BrojIndeksa = "IB260001",
                DatumRodjenja = new DateOnly(2000, 1, 1)
            });
        }

        public Student Dodaj(Student student)
        {
            student.Id = _sljedeciId++;
            student.DatumKreiranja = DateTime.Now;
            _students.Add(student);
            return student;
        }
        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
