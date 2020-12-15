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
        [Required]
        public int ResponsableId{get;set;}
        [Required]
        public int Exposicion{get;set;}
        public int Consecuencia{get;set;}
        public int Probabilidad{get;set;}
        public int ValorRiesgo{get;set;}
        public String NivelRiesgo{get;set;}
        public int PrioridadAtencion{get;set;}
        public String Accion{get;set;}
        public String Descripcion{get;set;}
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCompromiso{ get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? FechaCierre{ get; set; }
        public String EstatusCierre{get;set;}




        public virtual Subcategoria Subcategoria{get;set;}
        public virtual Categoria Categoria{get;set;}
        public virtual Area Area{get;set;}
        public virtual Colaborador Responsable{get;set;}
        
        
    }
}
