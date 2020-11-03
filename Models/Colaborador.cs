using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        }

        public int Id { get; set; }
        public int? DepartamentoId { get; set; }
        [Column(TypeName = "varchar(25)")]
        [Required]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }
        [Column(TypeName = "varchar(35)")]
        [Required]
        public string Puesto { get; set; }
        
        

        public virtual Departamento Departamento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }
        public virtual ICollection<CondicionInsegura> CondicionInseguras { get; set; }
        public virtual ICollection<Bbs> Bbss { get; set; }
    }
}
