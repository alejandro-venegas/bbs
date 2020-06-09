using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class IndicadorRiesgo
    {
        public IndicadorRiesgo()
        {
            CondicionesInseguras = new HashSet<CondicionesInseguras>();
        }

        public int IndicadorRiesgoId { get; set; }
        public string IndicadorRiesgo1 { get; set; }

        public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
    }
}
