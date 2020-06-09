using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class TipoObservado
    {
        public TipoObservado()
        {
            Bbs = new HashSet<Bbs>();
        }

        public int TipoObservadoId { get; set; }
        public string TipoObservado1 { get; set; }

        public virtual ICollection<Bbs> Bbs { get; set; }
    }
}
