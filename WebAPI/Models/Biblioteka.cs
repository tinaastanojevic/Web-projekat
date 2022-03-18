using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Biblioteka
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Naziv")]
        [MaxLength(40)]
        public string Naziv { get; set; }

        [Column("Adresa")]
        public string Adresa { get; set; }

        public List<Knjiga> Knjige { get; set; }

        public List<Clan> Clanovi { get; set; }
    }
}