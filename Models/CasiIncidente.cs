using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class CasiIncidente
    {
        public int CasiIncidenteId { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public int ObservadoId { get; set; }
        public int TurnoId { get; set; }
        public int JornadaId { get; set; }
        public int RiesgoId { get; set; }
        public int ColaboradorId { get; set; }
        public int CasualidadId { get; set; }
        public string DescripcionCasiIncidente { get; set; }

        public virtual Casualidad Casualidad { get; set; }
        public virtual Departamento Colaborador { get; set; }
        public virtual Area Proceso { get; set; }
        public virtual Proceso Proceso1 { get; set; }
        public virtual Observado ProcesoNavigation { get; set; }
        public virtual Riesgo Riesgo { get; set; }
        public virtual Jornada Turno { get; set; }
        public virtual Turno TurnoNavigation { get; set; }
    }
}
