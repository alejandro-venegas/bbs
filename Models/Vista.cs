using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bbs.Models
{
    public partial class Vista
    {
        
        public byte Id {get;set;}
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nombre{get;set;}
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Url{get;set;}
        public virtual ICollection<RolVista> RolVistas { get; set; }
    }
}