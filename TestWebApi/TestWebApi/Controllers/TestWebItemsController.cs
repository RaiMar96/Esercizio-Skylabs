using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestWebItemsController : Controller
    {
        private readonly TestContext _context;

        public TestWebItemsController(TestContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo cha implementa la chiamta post che permette l'inserimento nel DB dell'oggetto passato nel body della richiesta
        /// </summary>
        /// <param name="testWebItem">Oggetto da inserire nel db composto dalla coppia nome e prezzo</param>
        /// <returns>Oggetto inserito nel Bd in caso di successo, O messaggio di errore in caso di insuccesso</returns>
        [HttpPost("product")]
        public async Task<IActionResult> PostItem(TestWebItem testWebItem)
        {
            try { 
                _context.Add(testWebItem);
                var testWebItemRes = await _context.SaveChangesAsync();
                return Ok("Oggetto Creato");
            } 
            catch(Exception)
            {
                return BadRequest("Errore Durante L'inserimento");
            }
        }

        /// <summary>
        /// Metodo che implementa la Get sugli oggetti del DB ricercando sul nome passato tramite url
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Ritorna uno/nessuno/più elementi a seconda del risultato della query, se nessuno ritorna notFound</returns>
        [HttpGet("product/{name}")]
        public async Task<IActionResult> GetItemByName(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var testWebItem = await _context.TestItems
                .Where(m => Regex.IsMatch(m.Nome, name, RegexOptions.IgnoreCase))
                .ToListAsync();
            if (testWebItem == null)
            {
                return NotFound();
            }

            return Ok(testWebItem);
        }
    }
}
