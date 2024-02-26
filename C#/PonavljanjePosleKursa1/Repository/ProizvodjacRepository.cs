using Microsoft.EntityFrameworkCore;
using PonavljanjePosleKursa1.Interface;
using PonavljanjePosleKursa1.Models;
using PonavljanjePosleKursa1.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PonavljanjePosleKursa1.Repository
{
    public class ProizvodjacRepository : IProizvodjacRepository
    {
        private readonly AppDbContext _context;

        public ProizvodjacRepository(AppDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Proizvodjac> GetAll()
        {
            return _context.Proizvodjaci.OrderBy(p => p.Naziv);

        }

        public Proizvodjac GetById(int id)
        {
            return _context.Proizvodjaci.FirstOrDefault(p => p.Id == id);
        }

        public List<ProizvodjaciBrModelaProsecnaCenaDTO> ProizvodjaciProsek(int granica)
        {
            return _context.Telefoni.GroupBy(s => s.ProizvodjacId).Select(grupa =>
                new ProizvodjaciBrModelaProsecnaCenaDTO()
                {
                    Proizvodjac = _context.Proizvodjaci.Where(p => p.Id == grupa.Key).Select(s => s.Naziv).Single(),
                    ProsecnaCena = (double)grupa.Average(f => f.Cena),
                    NajjeftinijiTelefon = grupa.Min(t => t.Cena),

                }
                ).Where(dto => dto.ProsecnaCena < granica).OrderBy(dto => dto.Proizvodjac).ToList();
        }

        public List<ProizvodjacStatusDTO> PreuzmiStatuseProizvodjaca()
        {
            return _context.Proizvodjaci
                .Select(proizvodjac => new ProizvodjacStatusDTO
                {
                     Proizvodjac = proizvodjac.Naziv,
                     BrojModela = _context.Telefoni.Count(t => t.ProizvodjacId == proizvodjac.Id),
                    UkupnaKolicina = _context.Telefoni.Where(t => t.ProizvodjacId == proizvodjac.Id).Sum(t => t.Kolicina)
                })
                .OrderByDescending(dto => dto.UkupnaKolicina)
                .ToList();
        }

        public List<Proizvodjac> PretraziProizvodjacaPoImenu(string ime)
        {
            return _context.Proizvodjaci.Where(z => z.Naziv.Equals(ime)).OrderBy(z => z.Drzava)
                .ThenByDescending(z => z.Naziv).ToList();
        }

        public void Delete(Proizvodjac proizvodjac)
        {
            _context.Proizvodjaci.Remove(proizvodjac);
            _context.SaveChanges();
        }


    }
}
