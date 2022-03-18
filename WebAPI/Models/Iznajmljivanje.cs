using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI.Models
{
    public class Iznajmljivanje
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Datum")]
        public string Datum { get; set; }

        public Clan Clan { get; set; }

        public Knjiga Knjige { get; set; }
    }
}