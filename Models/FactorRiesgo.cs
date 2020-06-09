using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class FactorRiesgo
    {
        public FactorRiesgo()
        {
            CondicionesInseguras = new HashSet<CondicionesInseguras>();
        }

        public int FactorRiesgoId { get; set; }
        public string FactorRiesgo1 { get; set; }

        public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
    }
}
