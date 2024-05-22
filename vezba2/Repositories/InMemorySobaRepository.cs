using vezba2.Interfaces;
using vezba2.Models;

namespace vezba2.Repositories
{
    public class InMemorySobaRepository : ISobaRepository
    {

        private List<Soba> _sobaList = new List<Soba>() 
        {
            new Soba()
            {
                Id = 1, 
                Naziv = "Twin",
                Cena = 12000,
                IdHotela = 1
            },
             new Soba()
            {
                Id = 2,
                Naziv = "Double",
                Cena = 20000,
                IdHotela = 1
            },
              new Soba()
            {
                Id = 3,
                Naziv = "Deluxe",
                Cena = 50000,
                IdHotela = 2
            },
               new Soba()
            {
                Id = 4,
                Naziv = "Pogled na more",
                Cena = 30000,
                IdHotela = 2
            }
        };

        InMemoryHotelRepository hotelR = new InMemoryHotelRepository();
        public void AzurirajSobu(Soba s, int id)
        {
            foreach(Soba soba in _sobaList)
            {
                if(soba.Id == id)
                {
                    soba.Naziv = s.Naziv;
                    soba.Cena = s.Cena;
                    soba.IdHotela = s.IdHotela;
                }
            }
        }

        public void DodajSobuZaHotel(Soba s, int idHotela)
        {
            Hotel h = hotelR.VratiHotelSaId(idHotela);
            if(h == null)
            {
                throw new Exception("Hotel ne postoji u bazi!");
            }
            s.IdHotela = h.Id;
            _sobaList.Add(s);
        }

        public void ObrisiSobu(int id)
        {
            foreach(Soba s in _sobaList)
            {
                if(s.Id == id)
                {
                    _sobaList.Remove(s);
                }
            }
        }

        public List<Soba> VratiSobeOdredjenogHotela(int idHotela)
        {
            Hotel h = hotelR.VratiHotelSaId(idHotela);
            if (h == null)
            {
                throw new Exception("Hotel ne postoji u bazi!");
            }
            List<Soba> novaLista = new List<Soba>();
            foreach(Soba s in _sobaList)
            {
                if(s.IdHotela == h.Id)
                {
                    novaLista.Add(s);
                }
            }
            return novaLista;
        }

        public List<Soba> VratiSobeSaTekstomIzHotela(int idHotela, string tekst)
        {
            Hotel h = hotelR.VratiHotelSaId(idHotela);
            if (h == null)
            {
                throw new Exception("Hotel ne postoji u bazi!");
            }
            List<Soba> novaLista = new List<Soba>();
            foreach(Soba s in _sobaList)
            {
                if(s.IdHotela == h.Id && s.Naziv.Contains(tekst))
                {
                    novaLista.Add(s);
                }
            }
            return novaLista;
        }

        public Soba VratiSobuSaId(int id)
        {
            return _sobaList.FirstOrDefault(s => s.Id == id);
        }

        public List<Soba> VratiSveSobeSvihHotela()
        {
            return _sobaList;
        }
    }
}
