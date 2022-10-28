using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.DTOs
{
    public class VehiclePhotoDTO
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
       
        public IFormFile Foto { get; set; }
    }
}
