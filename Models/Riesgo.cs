﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bbs.Models
{
    public partial class Riesgo
    {
        public Riesgo()
        {
   
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
 
        public string Nombre { get; set; }


    }
}
