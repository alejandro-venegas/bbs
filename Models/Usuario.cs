using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public String Username {get; set;}
        public String Password {get;set;}
        public int RolId { get; set; }
        public int ColaboradorId { get; set; }

        public virtual Colaborador Colaborador { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
