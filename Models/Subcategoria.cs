using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Subcategoria
    {
        public Subcategoria()
        {
            CondicionInseguras = new HashSet<CondicionInsegura>();
        }

        public int Id { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

        public virtual Categoria Categoria{get;set;}

        public virtual ICollection<CondicionInsegura> CondicionInseguras { get; set; }
    }
}
