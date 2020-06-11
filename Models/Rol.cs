using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Rol
    {
       

        public int Id { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }
        public virtual ICollection<RolVista> RolVistas {get; set;}
    }
}
