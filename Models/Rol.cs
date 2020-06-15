using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Rol
    {
       

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion{ get; set; }
        public virtual ICollection<RolVista> RolVistas {get; set;}
    }
}
