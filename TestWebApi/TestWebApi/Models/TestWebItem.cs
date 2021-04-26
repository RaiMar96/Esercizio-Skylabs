using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    /// <summary>
    /// Classe che modella l'informazione salvata nel DB
    /// </summary>
    public class TestWebItem
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public float Prezzo { get; set; }
    }
}
