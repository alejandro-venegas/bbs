using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Subcategorias = new HashSet<Subcategoria>();
            CondicionInseguras = new HashSet<CondicionInsegura>();
        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Subcategoria> Subcategorias { get; set; }
        public virtual ICollection<CondicionInsegura> CondicionInseguras { get; set; } 
    }
}
