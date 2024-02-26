using PonavljanjePosleKursa1.Models;
using System.Collections.Generic;
using System.Linq;

namespace PonavljanjePosleKursa1.Interface
{
    public interface ITelefonRepository
    {
        public IQueryable<Telefon> GetAll();

        public Telefon GetById(int id);

        public List<Telefon> PretraziTelefonePoUpitu(string model);

        public void Add(Telefon telefon);

        public void Update(Telefon telefon);
        public void Delete(Telefon telefon);
        public IQueryable<Telefon> GetAllByParameters(decimal najmanje, decimal najvise);
    }
}
