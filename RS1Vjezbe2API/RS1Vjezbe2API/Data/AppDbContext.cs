using Microsoft.EntityFrameworkCore;
using RS1Vjezbe2API.Models;

namespace RS1Vjezbe2API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Studenti => Set<Student>();

        public DbSet<Smjer> Smjerovi => Set<Smjer>();
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
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Smjer)
                .WithMany(sm => sm.Studenti)
                .HasForeignKey(s => s.SmjerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Smjer>().HasData(
                new Smjer
                {
                    Id = 1,
                    Naziv = "Softverski inzinjering"

                },
                new Smjer
                {
                    Id = 2,
                    Naziv = "Razvoj softvera"
                }
                );
        }

    }
}
