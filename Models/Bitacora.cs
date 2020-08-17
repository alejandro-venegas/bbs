using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Bitacora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string DescripcionBitacora { get; set; }

        // public virtual Usuario Usuario { get; set; }
    }
}
