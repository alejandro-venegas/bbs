using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Efecto
    {
        public Efecto()
        {
            Incidente = new HashSet<Incidente>();
        }

        public int EfectoId { get; set; }
        public string Efecto1 { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
