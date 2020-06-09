using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SBBS.Models
{
    public partial class Actividad
    {
        public Actividad()
        {
            Incidente = new HashSet<Incidente>();
        }

        [DisplayName("Número de Id")]
        public int ActividadId { get; set; }
        [DisplayName("Nombre de actividad")]
        public string Actividad1 { get; set; }

        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
