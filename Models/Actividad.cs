﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace bbs.Models
{
    public partial class Actividad
    {
        public Actividad()
        {
            Incidentes = new HashSet<Incidente>();
        }

        
        public int Id { get; set; }
       
        public string Nombre { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}