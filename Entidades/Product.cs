using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Practica3.Entidades
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }



    }
}
