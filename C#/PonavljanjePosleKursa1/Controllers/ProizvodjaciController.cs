using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PonavljanjePosleKursa1.Interface;
using System.Linq;

namespace PonavljanjePosleKursa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodjaciController : ControllerBase
    {
        private readonly IProizvodjacRepository _proizvodjacRepository;

        public ProizvodjaciController(IProizvodjacRepository proizvodjacRepository)
        {
            _proizvodjacRepository = proizvodjacRepository;
        }

        // GET: api/Proizvodjaci
        [HttpGet]
        public IActionResult GetProizvodjaci()
        {

            return Ok(_proizvodjacRepository.GetAll().ToList());
        }

        // GET: api/Proizvodjac/5
        [HttpGet("{id}")]
        public IActionResult GetProizvodjac(int id)
        {
            var proizvodjac = _proizvodjacRepository.GetById(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return Ok(proizvodjac);
        }

        // GET: api/info?granica={}
        [Authorize]
        [HttpGet("info")]
        public IActionResult ProizvodjaciProsek(int granica)
        {
            return Ok(_proizvodjacRepository.ProizvodjaciProsek(granica));
        }

        [HttpGet("status")]
        public IActionResult GetBrojModela()
        {

            return Ok(_proizvodjacRepository.PreuzmiStatuseProizvodjaca().ToList());
        }

        [Authorize]
        [HttpGet("[controller]/potrazi")]
        public IActionResult GetProizvodjacPoNazivu(string ime)
        {
            return Ok(_proizvodjacRepository.PretraziProizvodjacaPoImenu(ime));
        }

        // DELETE: api/Telefoni/5
        [HttpDelete("[controller]/{id}")]
        public IActionResult DeleteProizvodjac(int id)
        {
            var proizvodjac = _proizvodjacRepository.GetById(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            _proizvodjacRepository.Delete(proizvodjac);
            return NoContent();
        }
    }
}
