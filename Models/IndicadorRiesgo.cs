using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class IndicadorRiesgo
    {
        public IndicadorRiesgo()
        {

        }

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Nombre { get; set; }

    }
}
