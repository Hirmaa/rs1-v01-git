namespace RS1Vjezbe2API.Dtos
{
    public class StudentDodajRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public DateOnly? DatumRodjenja { get; set; }
    }
}
