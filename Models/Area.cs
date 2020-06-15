// using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Area
    {
        public Area()
        {
            // Bbs = new HashSet<Bbs>();
            // CasiIncidente = new HashSet<CasiIncidente>();
            // CondicionesInseguras = new HashSet<CondicionesInseguras>();
            // Incidente = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre {get; set; }

        // public virtual ICollection<Bbs> Bbs { get; set; }
        // public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        // public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
        // public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
