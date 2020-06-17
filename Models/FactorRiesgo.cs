// using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class FactorRiesgo
    {
        public FactorRiesgo()
        {
            CondicionInseguras = new HashSet<CondicionInsegura>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CondicionInsegura> CondicionInseguras { get; set; }
    }
}
