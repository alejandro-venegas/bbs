using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Comportamiento
    {
        public Comportamiento()
        {
            // Bbs = new HashSet<Bbs>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion{ get; set; }

        // public virtual ICollection<Bbs> Bbs { get; set; }
    }
}
