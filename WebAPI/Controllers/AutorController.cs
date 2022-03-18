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
    public class AutorController : ControllerBase
    {
        public BibliotekaContext Context { get; set; }
        public AutorController(BibliotekaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiAutore")]
        [HttpGet]
        public ActionResult Preuzmi()
        {

            try
            {
                 var autori = Context.Autori;
                 return Ok(autori);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
        [Route("DodajAutora")]
        [HttpPost]
        public async Task<ActionResult> DodajAutora([FromBody] Autor autor)
        {

            var a = Context.Autori.Where(p => p.Ime == autor.Ime && p.Prezime == autor.Prezime).FirstOrDefault();
            if (a != null)
            {
                return BadRequest("Autor vec postoji");
            }
            if (string.IsNullOrWhiteSpace(autor.Ime) || autor.Ime.Length > 15)
            {
                return BadRequest("Pogresno ime");
            }
            if (string.IsNullOrWhiteSpace(autor.Prezime) || autor.Prezime.Length > 20)
            {
                return BadRequest("Pogresno prezime");
            }
            try
            {
                Context.Autori.Add(autor);
                await Context.SaveChangesAsync();
                return Ok($"Autor je dodat! ID je: {autor.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
