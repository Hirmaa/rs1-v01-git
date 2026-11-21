using System.ComponentModel.DataAnnotations;

namespace RS1Vjezbe2API.Dtos
{
    public class StudentDodajRequest
    {
        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string BrojIndeksa { get; set; }
        
        public DateOnly? DatumRodjenja { get; set; }
    }
}
