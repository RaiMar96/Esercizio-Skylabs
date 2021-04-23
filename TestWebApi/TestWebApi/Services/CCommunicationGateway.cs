using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

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

        public async Task<int> CreateItemAsync(TestWebItem testWebItem)
        {
            try
            {
                await _context.AddAsync(testWebItem);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<List<TestWebItem>> GetItemAsync(string name)
        {
            return await _context.TestItems
                .Where(m => Regex.IsMatch(m.Nome, name, RegexOptions.IgnoreCase))
                .ToListAsync(); ;
        }
    }
}
