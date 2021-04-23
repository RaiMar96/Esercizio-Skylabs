using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;
using TestWebApi.Models.DTO;

namespace TestWebApi.Services
{
    /// <summary>
    /// Implementazione dei servizi di comunicazione
    /// </summary>
    public class CCommunicationGateway : ICommunicationGateway
    {
        private readonly TestContext _context;

        public CCommunicationGateway(TestContext context)
        {
            _context = context;
        }

        private static DTOTestWebItem ItemToDTO(TestWebItem todoItem) =>
                                new DTOTestWebItem
                                {
                                    Nome = todoItem.Nome,
                                    Prezzo = todoItem.Prezzo
                                };
        private static List<DTOTestWebItem> ItemListToDTOList(List<TestWebItem> todoItem)
        {
            List<DTOTestWebItem> prova = new List<DTOTestWebItem>();
            foreach (TestWebItem el in todoItem)
            {
                prova.Add(ItemToDTO(el));
            }
            return prova;
        }


        public async Task<int> CreateItemAsync(DTOTestWebItem dtoTestWebItem)
        {
            try
            {
                var testWebItem = new TestWebItem {
                    Nome = dtoTestWebItem.Nome,
                    Prezzo = dtoTestWebItem.Prezzo           
                };
                await _context.AddAsync(testWebItem);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<List<DTOTestWebItem>> GetItemAsync(string name)
        {
            var list = await _context.TestItems
                .Where(m => m.Nome.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            var lista_DTO = ItemListToDTOList(list);
           
            return lista_DTO;
        }
    }
}
