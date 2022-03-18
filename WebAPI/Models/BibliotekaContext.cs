using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class BibliotekaContext : DbContext
    {
        public DbSet<Autor> Autori { get; set; }
        public DbSet<Biblioteka> Biblioteke { get; set; }
        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Iznajmljivanje> Iznajmljivanja { get; set; }
        public BibliotekaContext(DbContextOptions options) : base(options)
        {

        }
    }
}