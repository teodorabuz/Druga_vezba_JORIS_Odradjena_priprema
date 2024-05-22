using vezba2.Data;
using vezba2.Interfaces;
using vezba2.Models;

namespace vezba2.Repositories
{
    public class SqlHotelRepository : IHotelRepository
    {
        public void AzurirajHotel(Hotel h, int id)
        {
            MyAppContext context = new MyAppContext();
            var HotelIzBaze = context.Hotels.FirstOrDefault(hotel => hotel.Id == id);
            if(HotelIzBaze == null)
            {
                throw new Exception("Hotel nije pronadjen!");
            }
            HotelIzBaze.Naziv = h.Naziv;
            HotelIzBaze.Adresa = h.Adresa;
            HotelIzBaze.Opis = h.Opis;
            HotelIzBaze.BrojZvezdica = h.BrojZvezdica;
            context.SaveChanges();
        }

        public void DodajHotel(Hotel h)
        {
            MyAppContext context = new MyAppContext();
            var HotelIzBaze = context.Hotels.FirstOrDefault(hotel => hotel.Id == h.Id);
            if(HotelIzBaze != null)
            {
                throw new Exception("Hotel vec postoji u bazi!");
            }
            context.Hotels.Add(h);
            context.SaveChanges();
        }

        public void ObrisiHotel(int id)
        {
            MyAppContext context = new MyAppContext();
            var HotelIzBaze = context.Hotels.FirstOrDefault(hotel => hotel.Id == id);
            if (HotelIzBaze == null)
            {
                throw new Exception("Hotel ne postoji u bazi!");
            }
            context.Hotels.Remove(HotelIzBaze);
            context.SaveChanges();
        }

        public Hotel VratiHotelSaId(int id)
        {
            MyAppContext context = new MyAppContext();
            List<Hotel> hoteli = context.Hotels.ToList();
            foreach(Hotel h in hoteli)
            {
                if(h.Id == id)
                {
                    return h;
                }
            }
            return null;
        }

        public List<Hotel> VratiHotelSaTekstom(string tekst)
        {
            MyAppContext context = new MyAppContext();
            List<Hotel> hoteli = context.Hotels.ToList();
            List<Hotel> novaLista = new List<Hotel>();
            foreach(Hotel h in hoteli)
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
            MyAppContext context = new MyAppContext();
            return context.Hotels.ToList();
        }
    }
}
