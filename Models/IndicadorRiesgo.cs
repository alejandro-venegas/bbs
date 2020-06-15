using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class IndicadorRiesgo
    {
        public IndicadorRiesgo()
        {
            // CondicionesInseguras = new HashSet<CondicionesInseguras>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        // public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
    }
}
