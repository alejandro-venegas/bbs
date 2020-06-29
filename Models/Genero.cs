using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Incidentes = new HashSet<Incidente>();
            CasiIncidentes = new HashSet<CasiIncidente>();
        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }
    }
}
