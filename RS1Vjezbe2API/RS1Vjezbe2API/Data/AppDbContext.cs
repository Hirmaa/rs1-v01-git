using Microsoft.EntityFrameworkCore;
using RS1Vjezbe2API.Models;

namespace RS1Vjezbe2API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Studenti => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Ime = "Mahir",
                    Prezime = "Mustafic",
                    BrojIndeksa = "IB260001",
                    DatumRodjenja = new DateOnly(2004, 4, 3),
                    DatumKreiranja = new DateTime(2026, 11, 15),
                },
                new Student()
                {
                    Id = 2,
                    Ime = "Elina",
                    Prezime = "Eldarovna",
                    BrojIndeksa = "IB260002",
                    DatumRodjenja = new DateOnly(2004, 4, 8),
                    DatumKreiranja = new DateTime(2026, 11, 15),
                }
                );
        }

    }
}
