using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotekaController : ControllerBase
    {
        public BibliotekaContext Context { get; set; }
        public BibliotekaController(BibliotekaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiBiblioteke")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            var biblioteke = Context.Biblioteke
                 .Include(p => p.Knjige)
                 .ThenInclude(q => q.AutorKnjige)
                 .Include(p=>p.Clanovi);
            return Ok(biblioteke);
        }

         [Route("PreuzmiBiblioteku/{idBiblioteke}")]
        [HttpGet]
        public ActionResult PreuzmiBiblioteku(int idBiblioteke)
        {
            var biblioteka = Context.Biblioteke
                 .Include(p => p.Knjige)
                 .ThenInclude(q => q.AutorKnjige)
                 .Include(p=>p.Clanovi)
                 .Where(p=>p.ID==idBiblioteke).FirstOrDefault();
            return Ok(biblioteka);
        }

        [Route("DodajBiblioteku")]
        [HttpPost]
        public async Task<ActionResult> DodajBiblioteku([FromBody] Biblioteka biblioteka)
        {

            var b = Context.Biblioteke.Where(p => p.Naziv == biblioteka.Naziv).FirstOrDefault();
            if (b != null)
            {
                return BadRequest("Biblioteka vec postoji");
            }
            if (biblioteka.Naziv.Length > 40)
            {
                return BadRequest("Naziv biblioteke je predugacak");
            }
            try
            {
                Context.Biblioteke.Add(biblioteka);
                await Context.SaveChangesAsync();
                return Ok("Biblioteka je uspesno dodata!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
