using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Incidente
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public String Observado { get; set; }
        public int GeneroId { get; set; }
        public int TurnoId { get; set; }
        public int JornadaId { get; set; }
        public int EfectoId { get; set; }
        public int ClasificacionId { get; set; }
        public int ActividadId { get; set; }
        public int RiesgoId { get; set; }
        public int SupervisorId { get; set; }
        public int CausaBasicaId { get; set; }
        public int CausaInmediataId { get; set; }
        public int ParteCuerpoId { get; set; }
        public string Descripcion { get; set; }

        public virtual Actividad Actividad { get; set; }
        public virtual Area Area { get; set; }
        public virtual CausaBasica CausaBasica { get; set; }
        public virtual CausaInmediata CausaInmediata { get; set; }
        public virtual ParteCuerpo ParteCuerpo { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Colaborador Supervisor { get; set; }
        public virtual Riesgo Riesgo { get; set; }
        public virtual Efecto Efecto { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Jornada Jornada{get;set;}
        public virtual Proceso Proceso { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
