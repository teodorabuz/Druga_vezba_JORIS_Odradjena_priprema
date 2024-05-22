using vezba2.Interfaces;
using vezba2.Models;

namespace vezba2.Repositories
{
    public class InMemoryHotelRepository : IHotelRepository
    {

        private List<Hotel> _hotelList = new List<Hotel>() 
        {
            new Hotel()
            {
                Id = 1,
                Naziv = "Hyatt Regency",
                Adresa = "Novi Beograd",
                Opis = "Velik",
                BrojZvezdica = 5
            },
            new Hotel()
            {
                Id = 2,
                Naziv = "Metropolitan Palace",
                Adresa = "Vracar",
                Opis = "Luksuzan",
                BrojZvezdica = 4
            },
            new Hotel()
            {
                Id = 3,
                Naziv = "Hotel Sumadija",
                Adresa = "Banovo brdo",
                Opis = "Za proslave",
                BrojZvezdica = 4
            },
        };

        public void AzurirajHotel(Hotel h, int id)
        {
            foreach(Hotel hotel in _hotelList)
            {
                if(hotel.Id == id)
                {
                    hotel.Naziv = h.Naziv;
                    hotel.Adresa = h.Adresa;
                    hotel.Opis = h.Opis;
                    hotel.BrojZvezdica = h.BrojZvezdica;
                }
            }
        }

        public void DodajHotel(Hotel h)
        {
            if(h == null)
            {
                throw new Exception("GRESKA");
            }
            _hotelList.Add(h);
        }

        public void ObrisiHotel(int id)
        {
            foreach(Hotel h in _hotelList)
            {
                if(h.Id == id)
                {
                    _hotelList.Remove(h);
                }
            }
        }

        public Hotel VratiHotelSaId(int id)
        {
            return _hotelList.FirstOrDefault(h => h.Id == id);
        }

        public List<Hotel> VratiHotelSaTekstom(string tekst)
        {
            List<Hotel> novaLista = new List<Hotel>();
            foreach(Hotel h in _hotelList)
            {
                if (h.Naziv.Contains(tekst))
                {
                    novaLista.Add(h);
                }
            }
            return novaLista;
        }

        public List<Hotel> VratiSveHotele()
        {
            return _hotelList;
        }
    }
}
