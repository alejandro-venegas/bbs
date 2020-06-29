using System.ComponentModel.DataAnnotations;

namespace bbs.Models
{
    public class RolVista
    {
        [Required]
        public int RolId {get;set;}
        public Rol Rol {get;set;}
        [Required]
        public int VistaId { get; set; }
        public Vista Vista {get;set;}
    }
}