using System.ComponentModel.DataAnnotations;

namespace BerberKuafor.Models
{
    public class Personel
    {
        [Key]
        public int IDPersonel { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyad { get; set; }

        //public List<Musteri> Musteriler { get; set; }
    }
}
