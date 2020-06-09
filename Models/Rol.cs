using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int RolId { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
