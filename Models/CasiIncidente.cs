using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class CasiIncidente
    {
        public int Id { get; set; }
         [Column(TypeName = "datetime2")]
         [Required]
        public DateTime Fecha{ get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int ProcesoId { get; set; }
        [Required]
        public String Observado { get; set; }
        [Required]
        public int TurnoId { get; set; }
        [Required]
        public int JornadaId { get; set; }
        [Required]
        public int GeneroId{get;set;}
        [Required]
        public int RiesgoId { get; set; }
    
        [Required]
        public int CasualidadId { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual Casualidad Casualidad { get; set; }
        public virtual Area Area { get; set; }
        public virtual Genero Genero{get;set;}
        public virtual Proceso Proceso { get; set; }
        // public virtual Observado ProcesoNavigation { get; set; }
        public virtual Riesgo Riesgo { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
