using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class CasiIncidente
    {
        public int Id { get; set; }
        public DateTime FechaCasiIncidente { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public String Observado { get; set; }
        public int TurnoId { get; set; }
        public int JornadaId { get; set; }
        public int GeneroId{get;set;}
        public int RiesgoId { get; set; }
        public int SupervisorId { get; set; }
        public int CasualidadId { get; set; }
        public string Descripcion { get; set; }

        public virtual Casualidad Casualidad { get; set; }
        public virtual Colaborador Supervisor { get; set; }
        public virtual Area Area { get; set; }
        public virtual Genero Genero{get;set;}
        public virtual Proceso Proceso { get; set; }
        // public virtual Observado ProcesoNavigation { get; set; }
        public virtual Riesgo Riesgo { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
