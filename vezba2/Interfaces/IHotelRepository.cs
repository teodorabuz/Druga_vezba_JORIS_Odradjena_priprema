using vezba2.Models;

namespace vezba2.Interfaces
{
    public interface IHotelRepository
    {
        public void DodajHotel(Hotel h);
        public List<Hotel> VratiSveHotele();
        public Hotel VratiHotelSaId(int id);
        public void AzurirajHotel(Hotel h, int id);
        public void ObrisiHotel(int id);
        public List<Hotel> VratiHotelSaTekstom(string tekst);
    }
}
