using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Bbs
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public int ObservadorId { get; set; }
        public int AreaId { get; set; }
        public int ProcesoId { get; set; }
        public int ComportamientoId { get; set; }
        public int TipoObservadoId { get; set; }
        public int TipoComportamientoId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Colaborador Observador{get;set;}
        public virtual Proceso Proceso { get; set; }
        public virtual Comportamiento Comportamiento { get; set; }
        public virtual TipoObservado TipoObservado { get; set; }
        public virtual TipoComportamiento TipoComportamiento { get; set; }
    }
}
