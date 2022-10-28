using Microsoft.AspNetCore.Identity;

namespace Practica2.Models
{
    public class IdentityModels : IdentityUser
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Movil { get; set; }
    }
}

