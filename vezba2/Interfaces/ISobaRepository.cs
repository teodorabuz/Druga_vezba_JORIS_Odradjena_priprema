using vezba2.Data;
using vezba2.Models;

namespace vezba2.Interfaces
{
    public interface ISobaRepository
    {
        public void DodajSobuZaHotel(Soba s, int idHotela);
        public List<Soba> VratiSveSobeSvihHotela();
        public Soba VratiSobuSaId(int id);
        public void AzurirajSobu(Soba s, int id);
        public void ObrisiSobu(int id);
        public List<Soba> VratiSobeOdredjenogHotela(int idHotela);
        public List<Soba> VratiSobeSaTekstomIzHotela(int idHotela, string tekst);
    }
}
