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
    public class ClanController : ControllerBase
    {
        public BibliotekaContext Context { get; set; }
        public ClanController(BibliotekaContext context)
        {
            Context = context;
        }

        [Route("Clanovi")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            var clanovi = Context.Clanovi;
            return Ok(clanovi);
        }


        [Route("DodajClana/{idBiblioteke}")]
        [HttpPost]
        public async Task<ActionResult> DodajClana(int idBiblioteke,[FromBody] Clan clan)
        {

            var a = Context.Clanovi.Where(p => p.JMBG == clan.JMBG).FirstOrDefault();
            if (a != null)
            {
                return BadRequest("Clan vec postoji");
            }
            if (string.IsNullOrWhiteSpace(clan.Ime) || clan.Ime.Length > 15)
            {
                return BadRequest("Pogresno ime");
            }
            if (string.IsNullOrWhiteSpace(clan.Prezime) || clan.Prezime.Length > 20)
            {
                return BadRequest("Pogresno prezime");
            }
            if (clan.JMBG.Length != 13)
            {
                return BadRequest("JMBG mora da ima tacno 13 karaktera!");
            }
            try
            {
                var biblioteka = Context.Biblioteke
                 .Include(p=>p.Clanovi)
                .Where(p => p.ID == idBiblioteke).FirstOrDefault();
        
                biblioteka.Clanovi.Add(clan);
                await Context.SaveChangesAsync();
                return Ok("Clan je dodat!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("IzmeniClana")]
        [HttpPut]
        public async Task<ActionResult> PromeniClana([FromBody] Clan clan)
        {
            if (clan.JMBG.Length != 13)
            {
                return BadRequest("JMBG mora da ima tacno 13 karaktera!");
            }
            try
            {
                var clan1 = Context.Clanovi.Where(p => p.JMBG == clan.JMBG).FirstOrDefault();
                if (clan1 != null)
                {
                    if (string.IsNullOrWhiteSpace(clan.Ime) || clan.Ime.Length > 15)
                    {
                        return BadRequest("Pogresno ime");
                    }
                    if (string.IsNullOrWhiteSpace(clan.Prezime) || clan.Prezime.Length > 20)
                    {
                        return BadRequest("Pogresno prezime");
                    }
                    clan1.Ime = clan.Ime;
                    clan1.Prezime = clan.Prezime;
                    await Context.SaveChangesAsync();
                    return Ok("Clan je promenjen!");
                }
                else
                {
                    return BadRequest("Clan sa tim JMBG-om ne postoji!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("ObrisiClana")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiClana(string JMBG)
        {
            if (JMBG.Length != 13)
            {
                return BadRequest("JMBG mora da ima tacno 13 karaktera!");
            }
            try
            {
                var clan = Context.Clanovi.Where(p => p.JMBG == JMBG).FirstOrDefault();
                if (clan != null)
                {
                    Context.Clanovi.Remove(clan);
                    await Context.SaveChangesAsync();
                    return Ok("Clan je izbrisan!");

                }
                else
                {
                    return BadRequest("Ne postoji clan sa tim JMBG-om");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
