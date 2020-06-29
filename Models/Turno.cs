using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Turno
    {
        public Turno(){
            Incidentes = new HashSet<Incidente>();
            CasiIncidentes = new HashSet<CasiIncidente>();
        }

      

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Nombre { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }

   
    }
}
