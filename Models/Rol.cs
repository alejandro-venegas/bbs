using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Rol
    {
       

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Descripcion{ get; set; }
        public virtual ICollection<RolVista> RolVistas {get; set;}
        public virtual ICollection<Usuario> Usuarios{get;set;}
    }
}
