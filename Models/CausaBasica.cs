using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class CausaBasica
    {
        public CausaBasica()
        {
            Incidente = new HashSet<Incidente>();
        }

        public int CausaBasicaId { get; set; }
        public string CausaBasica1 { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
