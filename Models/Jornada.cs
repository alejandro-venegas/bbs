using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Jornada
    {
        public Jornada()
        {
            CasiIncidente = new HashSet<CasiIncidente>();
            Incidente = new HashSet<Incidente>();
        }

        public int JornadaId { get; set; }
        public string Jornada1 { get; set; }

        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
