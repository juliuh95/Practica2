using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica3.Entidades
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }



    }
}
