using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            // Bbs = new HashSet<Bbs>();
            // CasiIncidentes = new HashSet<CasiIncidente>();
            Colaboradores = new HashSet<Colaborador>();
            // CondicionesInseguras = new HashSet<CondicionesInseguras>();
            // Incidentes = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        public int GerenteId { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }
    
        
        public virtual Colaborador Gerente{get;set;}
    //     public virtual Colaborador ColaboradorNavigation { get; set; }
    //     public virtual ICollection<Bbs> Bbs { get; set; }
    //     public virtual ICollection<CasiIncidente> CasiIncidentes { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    //     public virtual ICollection<CondicionesInseguras> CondicionesInseguras { get; set; }
    //     public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}
