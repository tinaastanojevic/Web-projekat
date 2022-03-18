using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Knjiga
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        public string Naziv { get; set; }

        [Column("Godina")]
        public int Godina { get; set; }

        [Column("BrojStrana")]
        [Range(10, 2000)]
        public int BrojStrana { get; set; }

        public Autor AutorKnjige { get; set; }

        [JsonIgnore]
        public List<Iznajmljivanje> KnjigaClan { get; set; }
    }
}