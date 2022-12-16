using System.ComponentModel.DataAnnotations;

namespace Practica3.DTOs
{
    public class ProductTypeCreacionDTO
    {

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        
    }
}
