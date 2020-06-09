using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Observado
    {
        public Observado()
        {
            CasiIncidente = new HashSet<CasiIncidente>();
            Incidente = new HashSet<Incidente>();
        }

        public int ObservadoId { get; set; }
        public string NombreObservado { get; set; }

        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
