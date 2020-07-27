using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class CondicionInsegura
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Fecha{ get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int ProcesoId { get; set; }
        [Required]
        public int FactorRiesgoId { get; set; }
        [Required]
        public int IndicadorRiesgoId { get; set; }
        [Required]


        public virtual Area Area { get; set; }

        public virtual FactorRiesgo FactorRiesgo { get; set; }
        public virtual IndicadorRiesgo IndicadorRiesgo { get; set; }
        public virtual Proceso Proceso { get; set; }
    }
}
