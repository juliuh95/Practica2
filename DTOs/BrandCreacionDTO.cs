using System.ComponentModel.DataAnnotations;

namespace Practica2.DTOs
{
    public class BrandCreacionDTO
    {
    
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
