using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Bbs
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Fecha { get; set; }
        [Required]

        public int ObservadorId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int ProcesoId { get; set; }
        [Required]
        public int ComportamientoId { get; set; }
        [Required]
        public int TipoObservadoId { get; set; }
        [Required]
        public int TipoComportamientoId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Colaborador Observador{get;set;}
        public virtual Proceso Proceso { get; set; }
        public virtual Comportamiento Comportamiento { get; set; }
        public virtual TipoObservado TipoObservado { get; set; }
        public virtual TipoComportamiento TipoComportamiento { get; set; }
    }
}
