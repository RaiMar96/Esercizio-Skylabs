using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models.DTO
{
    public class DTOTestWebItem
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public float Prezzo { get; set; }
    }
}
