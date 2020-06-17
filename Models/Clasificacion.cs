﻿using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Clasificacion
    {
        public Clasificacion()
        {
            Incidentes = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}