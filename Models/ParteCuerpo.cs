using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class ParteCuerpo
    {
        public ParteCuerpo()
        {
            Incidente = new HashSet<Incidente>();
        }

        public int ParteId { get; set; }
        public string Parte { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
