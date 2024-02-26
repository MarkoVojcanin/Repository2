using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PonavljanjePosleKursa1.Interface;
using PonavljanjePosleKursa1.Models.DTO;
using PonavljanjePosleKursa1.Models;
using PonavljanjePosleKursa1.Repository;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace PonavljanjePosleKursa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoniController : ControllerBase
    {
        private readonly ITelefonRepository _telefonRepository;
        private readonly IMapper _mapper;


        public TelefoniController(ITelefonRepository telefonRepository, IMapper mapper)
        {
            _telefonRepository = telefonRepository;
            _mapper = mapper;
        }

        // GET: api/Telefoni
        [HttpGet]
        public IActionResult GetTelefoni()
        {

            return Ok(_telefonRepository.GetAll().ToList());
        }

        // GET: api/Telefon/5
        [HttpGet("{id}")]
        public IActionResult GetTelefon(int id)
        {
            var proizvodjac = _telefonRepository.GetById(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return Ok(proizvodjac);
        }

        [Authorize]
        [HttpGet("trazi")]
        public IActionResult GetTelefonPoUpitu(string upit)
        {
            return Ok(_telefonRepository.PretraziTelefonePoUpitu(upit));
        }


        // POST: api/Telefoni
        [HttpPost]
        public IActionResult PostTelefon(Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _telefonRepository.Add(telefon);
            return CreatedAtAction("GetTelefon", new { id = telefon.Id }, _mapper.Map<TelefonDTO>(telefon));


        }

        // PUT: api/Telefoni/5
        [HttpPut("{id}")]
        public IActionResult PutTelefon(int id, Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefon.Id)
            {
                return BadRequest();
            }

            try
            {
                _telefonRepository.Update(telefon);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<TelefonDTO>(telefon));
        }

        // DELETE: api/Telefoni/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTelefon(int id)
        {
            var telefon = _telefonRepository.GetById(id);
            if (telefon == null)
            {
                return NotFound();
            }

            _telefonRepository.Delete(telefon);
            return NoContent();
        }

        //POST: api/Telefoni/pretraga
       [HttpPost]
       [Route("/api/Telefoni/pretraga")]
        public IActionResult Pretraga(PretragaDTO dto)
        {
            if (dto.Najmanje < 0 || dto.Najvise < 0 || dto.Najmanje > dto.Najvise)
            {
                return BadRequest();
            }
            return Ok(_telefonRepository.GetAllByParameters(dto.Najmanje, dto.Najvise).ProjectTo<TelefonDTO>(_mapper.ConfigurationProvider).ToList());
        }

    }
}
