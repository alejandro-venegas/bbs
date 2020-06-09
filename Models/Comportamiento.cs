using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Comportamiento
    {
        public Comportamiento()
        {
            Bbs = new HashSet<Bbs>();
        }

        public int ComportamientoId { get; set; }
        public string Comportamiento1 { get; set; }
        public string DescripcionComportamiento { get; set; }

        public virtual ICollection<Bbs> Bbs { get; set; }
    }
}
