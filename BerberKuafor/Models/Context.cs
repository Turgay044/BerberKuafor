using Microsoft.EntityFrameworkCore;

namespace BerberKuafor.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LQKJ0N7; database=BerberDB; integrated security = true;");
        }
        public DbSet<Personel> Personels { get; set; }
    }
}
