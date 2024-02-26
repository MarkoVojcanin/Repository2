using System.ComponentModel.DataAnnotations;

namespace PonavljanjePosleKursa1.Models
{
    public class Telefon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Minimalna duzina je 3 a maksimalna je 120 karaktera.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Minimalna duzina je 2 a maksimalna je 30 karaktera.")]
        public string Os {get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [Range(0, 1000, ErrorMessage = "Vrednost mora biti između 0 i 1000.")]
        public int Kolicina { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [Range(1.0, 250000.0, ErrorMessage = "Vrednost mora biti između 1.0 i 250 000.0")]
        public decimal Cena { get; set; }

        public int ProizvodjacId {get; set; }
        public Proizvodjac Proizvodjac { get; set; }

    }
}
