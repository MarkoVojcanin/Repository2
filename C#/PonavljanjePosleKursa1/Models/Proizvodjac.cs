using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PonavljanjePosleKursa1.Models
{
    public class Proizvodjac
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [Range(0, 120, ErrorMessage = "Vrednost mora biti između 0 i 120.")]
        public string Naziv {get; set;}


        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(60, MinimumLength =2, ErrorMessage = "Minimalna duzina je 2 a maksimalna je 60 karaktera.")]
        public string Drzava { get; set;}


       

    }
}
