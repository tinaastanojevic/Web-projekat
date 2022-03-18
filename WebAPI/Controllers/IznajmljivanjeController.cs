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
    public class IznajmljivanjeController : ControllerBase
    {
        public BibliotekaContext Context { get; set; }
        public IznajmljivanjeController(BibliotekaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiIznajmljivanja")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            var iznajmljivanja = Context.Iznajmljivanja
                .Include(p => p.Clan)
                .Include(p=>p.Knjige);
            return Ok(iznajmljivanja);
        }

        [Route("PreuzmiIznajmljivanja/{idClana}")]
        [HttpGet]
        public ActionResult Preuzmi(int idClana)
        {
            var iznajmljivanja = Context.Iznajmljivanja
                .Include(p => p.Clan)
                .Include(p=>p.Knjige)
                .Where(p=>p.Clan.ID==idClana);
            return Ok(iznajmljivanja);
        }

        [Route("DodajIznajmljivanje/{datum}/{idClana}/{idKnjige}")]
        [HttpPost]
        public async Task<ActionResult> DodajIznajmljivanje(string datum,int idClana,int idKnjige)
        {
            try
            {
                var clan= Context.Clanovi.Where(p=>p.ID==idClana).FirstOrDefault();
                var knjiga= Context.Knjige.Where(p=>p.ID==idKnjige).FirstOrDefault();

                var vecPostoji=Context.Iznajmljivanja
                .Where(p=>p.Clan.ID==idClana && p.Knjige.ID==idKnjige).FirstOrDefault();
                
                if(vecPostoji==null)
                {
                    Iznajmljivanje iznajmljivanje=new Iznajmljivanje
                {
                    Datum=datum,
                    Clan=clan,
                    Knjige=knjiga
                };

                 Context.Iznajmljivanja.Add(iznajmljivanje);
                 await Context.SaveChangesAsync();
                 
                 return Ok("Uspesno dodavanje!");
                }
                else
                {
                    return BadRequest("Clan je vec iznajmio tu knjigu!");
                }
               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
