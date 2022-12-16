using System.ComponentModel.DataAnnotations;

namespace Practica3.DTOs
{
    public class HistoryCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
