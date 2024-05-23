﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TFGBackend.Models
{
    public class Usuario
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public UserRole Rol { get; set; }

        public enum UserRole
        {
            Admin = 1,
            StandardUser = 2,
            OwnerUser = 3
        }

        public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
        public int IdPartido { get; set; }
        public int IdProducto { get; set; }
        public virtual ICollection<UsuarioPartido> UsuarioPartidos { get; set; } = new List<UsuarioPartido>();
        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
