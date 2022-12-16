using System.ComponentModel.DataAnnotations;

namespace Practica3.DTOs
{
    public class ProductCreacionDTO
    {

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
