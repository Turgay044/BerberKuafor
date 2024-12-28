using System.ComponentModel.DataAnnotations;

namespace BerberKuafor.Models
{
    public class Musteri
    {
        [Key]
        public int IdMusteri { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string MusteriMail { get; set; }

        //public Personel person { get; set; }
    }
}
