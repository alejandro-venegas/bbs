using System;
using System.Collections.Generic;

namespace SBBS.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Bbs = new HashSet<Bbs>();
            CasiIncidente = new HashSet<CasiIncidente>();
            Colaborador = new HashSet<Colaborador>();
            CondicionesInseguras = new HashSet<CondicionesInseguras>();
            Incidente = new HashSet<Incidente>();
        }

        public int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }
        public int ColaboradorId { get; set; }

        public virtual Colaborador ColaboradorNavigation { get; set; }
        public virtual ICollection<Bbs> Bbs { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidente { get; set; }
        public virtual ICollection<Colaborador> Colaborador { get; set; }
        public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
        public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
