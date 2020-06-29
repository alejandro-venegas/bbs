using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class ParteCuerpo
    {
        public ParteCuerpo()
        {
            Incidentes = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Nombre { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}
