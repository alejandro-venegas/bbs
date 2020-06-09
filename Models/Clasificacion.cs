using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Clasificacion
    {
        public Clasificacion()
        {
            Incidente = new HashSet<Incidente>();
        }

        public int ClasificacionId { get; set; }
        public string Clasificacion1 { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
