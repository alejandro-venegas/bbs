using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            DepartamentoNavigation = new HashSet<Departamento>();
            Usuario = new HashSet<Usuario>();
        }

        public int ColaboradorId { get; set; }
        public string NombreColaborador { get; set; }
        public string ApellidoColaborador { get; set; }
        public string PuestoColaborador { get; set; }
        public int DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Departamento> DepartamentoNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
