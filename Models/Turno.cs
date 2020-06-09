using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Turno
    {
        public Turno()
        {
            CasiIncidente = new HashSet<CasiIncidente>();
            Incidente = new HashSet<Incidente>();
        }

        public int TurnoId { get; set; }
        public string Turno1 { get; set; }

        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
