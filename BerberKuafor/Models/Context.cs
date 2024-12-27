using Microsoft.EntityFrameworkCore;

namespace BerberKuafor.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\MSSQL; database=BerberDB; integrated security = true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Musteri> Musteriler {  get; set; }   
    }
}
