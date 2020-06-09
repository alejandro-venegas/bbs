using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Bitacora
    {
        public int LogId { get; set; }
        public DateTime FechaBitacora { get; set; }
        public int UsuarioId { get; set; }
        public string DescripcionBitacora { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
