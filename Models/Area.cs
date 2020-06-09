using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Area
    {
        public Area()
        {
            Bbs = new HashSet<Bbs>();
            CasiIncidente = new HashSet<CasiIncidente>();
            CondicionesInseguras = new HashSet<CondicionesInseguras>();
            Incidente = new HashSet<Incidente>();
        }

        public int AreaId { get; set; }
        public string Area1 { get; set; }

        public virtual ICollection<Bbs> Bbs { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
