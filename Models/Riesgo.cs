using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Riesgo
    {
        public Riesgo()
        {
            CasiIncidente = new HashSet<CasiIncidente>();
            Incidente = new HashSet<Incidente>();
        }

        public int RiegoId { get; set; }
        public string Riesgo1 { get; set; }

        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
