using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacora = new HashSet<Bitacora>();
        }

        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public int ColaboradorId { get; set; }

        public virtual Colaborador Colaborador { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
    }
}
