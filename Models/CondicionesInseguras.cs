using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class CondicionInsegura
    {
        public int Id { get; set; }
        public DateTime FechaCondicion { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public int FactorRiesgoId { get; set; }
        public int IndicadorRiesgoId { get; set; }
        public int SupervisorId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Colaborador Supervisor { get; set; }
        public virtual FactorRiesgo FactorRiesgo { get; set; }
        public virtual IndicadorRiesgo IndicadorRiesgo { get; set; }
        public virtual Proceso Proceso { get; set; }
    }
}
