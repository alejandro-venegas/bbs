using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            // Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public int? DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }
        // public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
