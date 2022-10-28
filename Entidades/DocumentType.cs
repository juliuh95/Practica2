using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica2.Entidades
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }


    }
}
