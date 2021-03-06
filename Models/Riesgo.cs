﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bbs.Models
{
    public partial class Riesgo
    {
        public Riesgo()
        {
            Incidentes = new HashSet<Incidente>();
            CasiIncidentes = new HashSet<CasiIncidente>();
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
 
        public string Nombre { get; set; }

        public int IncidenteId { get; set;}
        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }
        
    }
}
