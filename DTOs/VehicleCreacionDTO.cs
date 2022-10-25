using System.ComponentModel.DataAnnotations;

namespace Practica2.DTOs
{
    public class VehicleCreacionDTO
    {

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
