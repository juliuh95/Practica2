using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica3.DTOs
{
    public class ProductPhotoCreacionDTO
    {
      
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
     
        public IFormFile Foto { get; set; }
    }
}
