using PonavljanjePosleKursa1.Models;
using PonavljanjePosleKursa1.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PonavljanjePosleKursa1.Interface
{
    public interface IProizvodjacRepository
    {
        public IQueryable<Proizvodjac> GetAll();

        public Proizvodjac GetById(int id);

        public List<ProizvodjaciBrModelaProsecnaCenaDTO> ProizvodjaciProsek(int granica);

        public List<ProizvodjacStatusDTO> PreuzmiStatuseProizvodjaca();

        public List<Proizvodjac> PretraziProizvodjacaPoImenu(string ime);
        public void Delete(Proizvodjac proizvodjac);
    }
}
