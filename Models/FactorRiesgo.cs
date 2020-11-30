﻿// using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class FactorRiesgo
    {
        public FactorRiesgo()
        {

        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

    }
}
