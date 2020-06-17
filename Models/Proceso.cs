using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bbs.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            Bbss = new HashSet<Bbs>();
            CasiIncidentes = new HashSet<CasiIncidente>();
            CondicionInseguras = new HashSet<CondicionInsegura>();
            Incidentes = new HashSet<Incidente>();
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Bbs> Bbss { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }
        public virtual ICollection<CondicionInsegura> CondicionInseguras { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}
