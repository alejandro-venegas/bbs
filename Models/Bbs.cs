using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Bbs
    {
        public string BbsId { get; set; }
        public string FechaBbs { get; set; }
        public int ColaboradorId { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public int ComportamientoId { get; set; }
        public int TipoObservadoId { get; set; }
        public int TipoComportamientoId { get; set; }

        public virtual Area Colaborador { get; set; }
        public virtual Proceso Colaborador1 { get; set; }
        public virtual Departamento ColaboradorNavigation { get; set; }
        public virtual Comportamiento Comportamiento { get; set; }
        public virtual TipoObservado ComportamientoNavigation { get; set; }
        public virtual TipoComportamiento TipoComportamiento { get; set; }
    }
}
