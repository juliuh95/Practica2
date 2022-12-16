using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica3.DTOs
{
    public class ProductPhotoDTO
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Foto { get; set; }


    }
}
