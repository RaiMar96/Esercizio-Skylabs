using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestWebItemsController : Controller
    {
        private readonly ICommunicationGateway _communicationService;

        public TestWebItemsController(ICommunicationGateway CommGtw)
        {
            _communicationService = CommGtw;
        }

        /// <summary>
        /// Metodo cha implementa la chiamta post che permette l'inserimento nel DB dell'oggetto passato nel body della richiesta
        /// </summary>
        /// <param name="testWebItem">Oggetto da inserire nel db composto dalla coppia nome e prezzo</param>
        /// <returns>Oggetto inserito nel Bd in caso di successo, O messaggio di errore in caso di insuccesso</returns>
        [HttpPost("product")]
        public async Task<IActionResult> PostItem(TestWebItem testWebItem)
        {
           var res = await _communicationService.CreateItemAsync(testWebItem);
            if(res == 1)
            {
                return Ok("Oggetto Creato");
            }
            return BadRequest("Errore Durante La creazione");
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

            var testWebItem = await _communicationService.GetItemAsync(name);

            if (testWebItem.Count() == 0)
            {
                return NotFound();
            }

            return Ok(testWebItem);
        }
    }
}
