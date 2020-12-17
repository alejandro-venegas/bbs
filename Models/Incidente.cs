using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Incidente
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Fecha { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int ProcesoId { get; set; }
        [Required]
        public int? ObservadoId { get; set; }
        [Required]
        public int GeneroId { get; set; }
        [Required]
        public int TurnoId { get; set; }
        [Required]
        public int JornadaId { get; set; }
        [Required]
        public int EfectoId { get; set; }
        [Required]
        public int ClasificacionId { get; set; }
        [Required]
        public int ActividadId { get; set; }
        [Required]
        public int RiesgoId { get; set; }

        [Required]
        public int CausaBasicaId { get; set; }
        [Required]
        public int CausaInmediataId { get; set; }
        [Required]
        public int ParteCuerpoId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Descripcion { get; set; }
        
        [NotMapped]
        public string Label {get; set;}
        [NotMapped]
        public int Count {get; set;}

        public virtual Actividad Actividad { get; set; }
        public virtual Area Area { get; set; }
        public virtual CausaBasica CausaBasica { get; set; }
        public virtual CausaInmediata CausaInmediata { get; set; }
        public virtual ParteCuerpo ParteCuerpo { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Riesgo Riesgo { get; set; }
        public virtual Efecto Efecto { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Jornada Jornada{get;set;}
        public virtual Proceso Proceso { get; set; }
        public virtual Turno Turno { get; set; }
        public virtual Colaborador Observado {get;set;}
    }
}
