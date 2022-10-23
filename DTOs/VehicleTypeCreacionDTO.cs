using System.ComponentModel.DataAnnotations;

namespace Practica2.DTOs
{
    public class VehicleTypeCreacionDTO
    {

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
