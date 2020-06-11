using System.Collections.Generic;
namespace bbs.Models
{
    public partial class Vista
    {
        
        public int Id {get;set;}
        public string NombreVista{get;set;}
        public virtual ICollection<RolVista> RolVistas { get; set; }
    }
}