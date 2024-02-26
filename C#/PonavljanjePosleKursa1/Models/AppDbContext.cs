using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PonavljanjePosleKursa1.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Proizvodjac> Proizvodjaci { get; set; }
        public DbSet<Telefon> Telefoni { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvodjac>().HasData(
                new Proizvodjac() { Id = 1, Naziv = "Xiamoi", Drzava = "Kina"},
                new Proizvodjac() { Id = 2, Naziv = "Apple", Drzava = "SAD" },
                new Proizvodjac() { Id = 3, Naziv = "Huawei", Drzava = "Kina" }
            );

            modelBuilder.Entity<Telefon>().HasData(
                new Telefon()
                {
                    Id = 1,
                    Model = "A94",
                    Os= "Android",
                    Kolicina = 12,
                    Cena = 31125.42m,
                    ProizvodjacId = 3

                },
               new Telefon()
               {
                   Id = 2,
                   Model = "13T Pro",
                   Os = "Android",
                   Kolicina = 7,
                   Cena = 104999.99m,
                   ProizvodjacId = 1 

               },
                new Telefon()
                {
                    Id = 3,
                    Model = "11",
                    Os = "iOS",
                    Kolicina = 17,
                    Cena = 71290.35m,
                    ProizvodjacId = 2

                },
                new Telefon()
                {
                    Id = 4,
                    Model = "Reno10 Pro",
                    Os = "Android",
                    Kolicina = 4,
                    Cena = 68264.74m,
                    ProizvodjacId = 3

                },
                new Telefon()
                {
                    Id = 5,
                    Model = "12 Lite",
                    Os = "Android",
                    Kolicina = 5,
                    Cena = 4499956,
                    ProizvodjacId = 1

                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

