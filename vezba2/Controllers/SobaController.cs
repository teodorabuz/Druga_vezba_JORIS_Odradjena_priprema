using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vezba2.Interfaces;
using vezba2.Models;

namespace vezba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobaController : ControllerBase
    {
        ISobaRepository _sobaRepository;
        public SobaController(ISobaRepository sobaRepository)
        {
            _sobaRepository = sobaRepository;
        }


        [HttpPost("dodaj-sobu/{idHotela}")]
        public void DodajSobuZaHotel([FromBody] Soba s, int idHotela)
        {
            _sobaRepository.DodajSobuZaHotel(s, idHotela);
        }


        [HttpGet("vrati-sve-sobe")]
        public List<Soba> VratiSveSobeSvihHotela()
        {
            return _sobaRepository.VratiSveSobeSvihHotela();
        }


        [HttpGet("vrati-sobu-sa-id/{id}")]
        public Soba VratiSobuSaId(int id)
        {
            return _sobaRepository.VratiSobuSaId(id);
        }


        [HttpPut("azuriraj-sobu/{id}")]
        public void AzurirajSobu([FromBody] Soba s, int id)
        {
            _sobaRepository.AzurirajSobu(s, id);
        }

        [HttpDelete("obrisi-hotel/{id}")]
        public void ObrisiHotel(int id)
        {
            _sobaRepository.ObrisiSobu(id);
        }

        [HttpGet("vrati-sobe-hotela/{idHotela}")]
        public List<Soba> VratiSobeOdredjenogHotela(int idHotela)
        {
            return _sobaRepository.VratiSobeOdredjenogHotela(idHotela);
        }

        [HttpGet("vrati-sobe-sa-tekstom/{idHotela}/{tekst}")]
        public List<Soba> VratiSobeSaTekstomIzHotela(int idHotela, string tekst)
        {
            return _sobaRepository.VratiSobeSaTekstomIzHotela(idHotela, tekst);
        }




    }
}
