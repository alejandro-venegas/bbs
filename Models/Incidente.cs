using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Incidente
    {
        public int Id { get; set; }
        public DateTime FechaIncidente { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public int ObservadoId { get; set; }
        public int GeneroId { get; set; }
        public int TurnoId { get; set; }
        public int JornadaId { get; set; }
        public int EfectoId { get; set; }
        public int ClasificacionId { get; set; }
        public int ActividadId { get; set; }
        public int RiesgoId { get; set; }
        public int ColaboradorId { get; set; }
        public int CausaBasicaId { get; set; }
        public int CausaInmediataId { get; set; }
        public int ParteId { get; set; }
        public string Descripcion { get; set; }

        public virtual Actividad Actividad { get; set; }
        public virtual Area Area { get; set; }
        public virtual CausaBasica CausaBasica { get; set; }
        public virtual CausaInmediata CausaInmediata { get; set; }
        public virtual ParteCuerpo CausaInmediataNavigation { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Departamento Colaborador { get; set; }
        public virtual Riesgo ColaboradorNavigation { get; set; }
        public virtual Jornada Efecto { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Proceso Observado { get; set; }
        public virtual Turno ObservadoNavigation { get; set; }
        public virtual Efecto Proceso { get; set; }
        public virtual Observado ProcesoNavigation { get; set; }
    }
}
