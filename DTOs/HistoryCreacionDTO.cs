using System.ComponentModel.DataAnnotations;

namespace Practica2.DTOs
{
    public class HistoryCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
