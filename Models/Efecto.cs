// using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Efecto
    {
        public Efecto()
        {
            // Incidente = new HashSet<Incidente>();
        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

        // public virtual ICollection<Incidente> Incidente { get; set; }
    }
}
