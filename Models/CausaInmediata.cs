using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class CausaInmediata
    {
        public CausaInmediata()
        {
            Incidente = new HashSet<Incidente>();
        }

        public int CausaInmediataId { get; set; }
        public string CausaInmediata1 { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
