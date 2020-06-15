using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class CausaBasica
    {
        public CausaBasica()
        {
            // Incidente = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        public string Nombre {get; set; }

        // public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
