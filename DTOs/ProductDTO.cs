using System.ComponentModel.DataAnnotations;

namespace Practica3.DTOs
{
    public class ProductDTO
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
