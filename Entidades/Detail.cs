﻿using System.ComponentModel.DataAnnotations;

namespace Practica2.Entidades
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
