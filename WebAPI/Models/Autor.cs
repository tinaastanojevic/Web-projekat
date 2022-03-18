using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Autor
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Ime")]
        [MaxLength(15)]
        public string Ime { get; set; }

        [Column("Prezime")]
        [MaxLength(20)]
        public string Prezime { get; set; }


        [JsonIgnore]
        public List<Knjiga> Knjige { get; set; }
    }
}