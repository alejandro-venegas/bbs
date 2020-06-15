using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Observado
    {
        public Observado()
        {
            // CasiIncidente = new HashSet<CasiIncidente>();
            // Incidente = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        // public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        // public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
