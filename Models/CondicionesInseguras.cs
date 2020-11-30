using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbs.Models
{
    public partial class CondicionInsegura
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Fecha{ get; set; }
         [Required]
        public int CategoriaId{get;set;}
  
        [Required]
        public int SubcategoriaId{get;set;}
        [Required]
        public int AreaId{get;set;}

        public virtual Subcategoria Subcategoria{get;set;}
        public virtual Categoria Categoria{get;set;}
        public virtual Area Area{get;set;}
        public virtual Colaborador Colaborador{get;set;}
        
        
    }
}
