using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vezba2.Interfaces;
using vezba2.Models;

namespace vezba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }



        [HttpPost("dodaj-hotel")]
        public void DodajHotel([FromBody] Hotel h)
        {
            _hotelRepository.DodajHotel(h);
        }


        [HttpGet("vrati-sve-hotele")]
        public List<Hotel> VratiSveHotele()
        {
            return _hotelRepository.VratiSveHotele();
        }

        [HttpGet("vrati-hotel-sa-id/{id}")]
        public Hotel VratiHotelSaId(int id)
        {
            return _hotelRepository.VratiHotelSaId(id);
        }

        [HttpPut("azuriraj-hotel/{id}")]
        public void AzurirajHotel([FromBody] Hotel h, int id)
        {
            _hotelRepository.AzurirajHotel(h, id);
        }


        [HttpDelete("obrisi-hotel/{id}")]
        public void ObrisiHotel(int id)
        {
            _hotelRepository.ObrisiHotel(id);
        }


        [HttpGet("vrati-hotele-sa-teklstom/{tekst}")]
        public List<Hotel> VratiHoteleSaTekstom(string tekst)
        {
            return _hotelRepository.VratiHotelSaTekstom(tekst);
        }


    }
}
