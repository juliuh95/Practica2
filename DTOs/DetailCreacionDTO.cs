using System.ComponentModel.DataAnnotations;

namespace Practica3.DTOs
{
    public class DetailCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
