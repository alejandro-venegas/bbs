using System;
using System.Collections.Generic;

namespace bbs.Models
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Incidentes = new HashSet<Incidente>();
            CasiIncidentes = new HashSet<CasiIncidente>();
            CondicionInseguras = new HashSet<CondicionInsegura>();
            Bbss = new HashSet<Bbs>();
            // Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public int? DepartamentoId { get; set; }
        

        public virtual Departamento Departamento { get; set; }
        // public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }
        public virtual ICollection<CondicionInsegura> CondicionInseguras { get; set; }
        public virtual ICollection<Bbs> Bbss { get; set; }
    }
}
