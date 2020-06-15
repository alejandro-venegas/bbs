using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class CondicionesInseguras
    {
        public int CondicionesId { get; set; }
        public DateTime FechaCondicion { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public int FactorRiesgoId { get; set; }
        public int IndicadorRiesgoId { get; set; }
        public int ColaboradorId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Departamento Colaborador { get; set; }
        public virtual FactorRiesgo FactorRiesgo { get; set; }
        public virtual IndicadorRiesgo IndicadorRiesgo { get; set; }
        public virtual Proceso Proceso { get; set; }
    }
}
