using System.ComponentModel.DataAnnotations;

namespace Practica2.DTOs
{
    public class VehicleTypeDTO
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

    }
}
