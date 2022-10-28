using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.DTOs
{
    public class VehiclePhotoCreacionDTO
    {
      
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
     
        public IFormFile Foto { get; set; }
    }
}
