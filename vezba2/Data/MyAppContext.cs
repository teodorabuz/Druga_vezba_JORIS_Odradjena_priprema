using Microsoft.EntityFrameworkCore;
using vezba2.Models;

namespace vezba2.Data
{
    public class MyAppContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Soba> Sobe {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //*base.OnConfiguring(optionsBuilder);
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Database=Hotel_Baza_Podataka;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
