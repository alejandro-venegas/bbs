using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class TipoComportamiento
    {
        public TipoComportamiento()
        {
            Bbs = new HashSet<Bbs>();
        }

        public int TipoComportamientoId { get; set; }
        public string TipoComportamiento1 { get; set; }

        public virtual ICollection<Bbs> Bbs { get; set; }
    }
}
