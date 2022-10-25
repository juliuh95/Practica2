using System.ComponentModel.DataAnnotations;

namespace Practica2.DTOs
{
    public class DetailCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
