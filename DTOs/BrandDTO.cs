using System.ComponentModel.DataAnnotations;

namespace Practica3.DTOs
{
    public class BrandDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
