using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Casualidad
    {
        public Casualidad()
        {
            // CasiIncidente = new HashSet<CasiIncidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        // public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
    }
}
