using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class TipoComportamiento
    {
        public TipoComportamiento()
        {
            // Bbs = new HashSet<Bbs>();
        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

        // public virtual ICollection<Bbs> Bbs { get; set; }
    }
}
