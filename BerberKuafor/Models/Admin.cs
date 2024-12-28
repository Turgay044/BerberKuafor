using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerberKuafor.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName ="Varchar(20)")]
        public string Kullanici { get; set; }
        [Column(TypeName ="Varchar(50)")]
        public string KullaniciMail { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string Sifre { get; set; }

    }
}
