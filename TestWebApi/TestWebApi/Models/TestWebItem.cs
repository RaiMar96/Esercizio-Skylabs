using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    /// <summary>
    /// Classe che modella l'informazione salvata nel DB
    /// </summary>
    public class TestWebItem
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public float Prezzo { get; set; }
    }
}
