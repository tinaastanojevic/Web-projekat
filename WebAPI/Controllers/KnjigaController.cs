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
    public class KnjigaController : ControllerBase
    {
        public BibliotekaContext Context { get; set; }
        public KnjigaController(BibliotekaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiKnjige")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            var knjige = Context.Knjige
                .Include(p => p.AutorKnjige);
            return Ok(knjige);
        }

        [Route("DodajKnjigu/{idBiblioteke}")]
        [HttpPost]
        public async Task<ActionResult> DodajKnjigu(int idBiblioteke, [FromBody] Knjiga knjiga)
        {

            var b = Context.Knjige
            .Where(p => p.Naziv == knjiga.Naziv).FirstOrDefault();

            if (b != null)
            {
                return BadRequest("Knjiga vec postoji");
            }
            if (knjiga.BrojStrana < 10 || knjiga.BrojStrana > 2000)
            {
                return BadRequest("Knjiga mora da ima izmedju 10 i 2000 strana!");
            }
            try
            {

                var biblioteka = Context.Biblioteke
                 .Include(p => p.Knjige)
                .Where(p => p.ID == idBiblioteke).FirstOrDefault();

                biblioteka.Knjige.Add(knjiga);
                await Context.SaveChangesAsync();
                return Ok("Knjiga je uspesno dodata!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiKnjigu/{naziv}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiKnjigu(string naziv)
        {
            try
            {
                var knjiga = Context.Knjige.Where(p => p.Naziv == naziv).FirstOrDefault();
                var iznajmljena=Context.Iznajmljivanja
                .Include(p=>p.Knjige)
                .Where(q=>q.Knjige.Naziv==naziv).FirstOrDefault();
                
                if (knjiga != null && iznajmljena==null)
                {
                    Context.Knjige.Remove(knjiga);
                   await Context.SaveChangesAsync();
                    return Ok("Knjiga je izbrisana!");

                }
                else
                {
                    return BadRequest("Ne postoji knjiga sa tim nazivom ili je iznajmljena od strane nekog korisnika!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }


}
