using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Casualidad
    {
        public Casualidad()
        {
            CasiIncidente = new HashSet<CasiIncidente>();
        }

        public int CasualidadId { get; set; }
        public string Casualidad1 { get; set; }

        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
    }
}
