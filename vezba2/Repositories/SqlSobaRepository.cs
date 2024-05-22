using vezba2.Data;
using vezba2.Interfaces;
using vezba2.Models;

namespace vezba2.Repositories
{
    public class SqlSobaRepository : ISobaRepository
    {
        public void AzurirajSobu(Soba s, int id)
        {
            MyAppContext context = new MyAppContext();
            List<Soba> sobe = context.Sobe.ToList();
            foreach(Soba soba in sobe)
            {
                if(soba.Id == id)
                {
                    soba.Naziv = s.Naziv;
                    soba.Cena = s.Cena;
                    soba.IdHotela = s.IdHotela;
                }
            }
            context.SaveChanges();
        }

        public void DodajSobuZaHotel(Soba s, int idHotela)
        {
            MyAppContext context = new MyAppContext();
            var HotelIzBaze = context.Hotels.FirstOrDefault(h=>h.Id == idHotela);
            if(HotelIzBaze == null)
            {
                throw new Exception("Hotel nije pronadjen u bazi!");
            }
            s.IdHotela = HotelIzBaze.Id;
            context.Sobe.Add(s);
            context.SaveChanges();
        }

        public void ObrisiSobu(int id)
        {
            MyAppContext context = new MyAppContext();
            context.Sobe.Remove(VratiSobuSaId(id));
            context.SaveChanges();
        }

        public List<Soba> VratiSobeOdredjenogHotela(int idHotela)
        {
            MyAppContext context = new MyAppContext();
            var HotelIzBaze = context.Hotels.FirstOrDefault(h => h.Id == idHotela);
            if (HotelIzBaze == null)
            {
                throw new Exception("Hotel nije pronadjen u bazi!");
            }
            List<Soba> sobe = context.Sobe.ToList();
            List<Soba> novaLista = new List<Soba>();
            foreach(Soba s in sobe)
            {
                if(s.IdHotela == idHotela)
                {
                    novaLista.Add(s);
                }
            }
            return novaLista;
        }

        public List<Soba> VratiSobeSaTekstomIzHotela(int idHotela, string tekst)
        {
            MyAppContext context = new MyAppContext();
            var HotelIzBaze = context.Hotels.FirstOrDefault(h => h.Id == idHotela);
            if (HotelIzBaze == null)
            {
                throw new Exception("Hotel nije pronadjen u bazi!");
            }
            List<Soba> sobe = context.Sobe.ToList();
            List<Soba> novaLista = new List<Soba>();
            foreach (Soba s in sobe)
            {
                if (s.IdHotela == idHotela && s.Naziv.Contains(tekst))
                {
                    novaLista.Add(s);
                }
            }
            return novaLista;
        }

        public Soba VratiSobuSaId(int id)
        {
            MyAppContext context = new MyAppContext();
            return context.Sobe.FirstOrDefault(s => s.Id == id);
        }

        public List<Soba> VratiSveSobeSvihHotela()
        {
            MyAppContext context = new MyAppContext();
            return context.Sobe.ToList();
        }
    }
}
