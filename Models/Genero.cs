using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Incidente = new HashSet<Incidente>();
        }

        public int GeneroId { get; set; }
        public string Genero1 { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
