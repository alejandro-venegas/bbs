using System.Collections.Generic;
namespace bbs.DTOs
{
    public class RolToInsert
    {
        public int Id { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }
        public List<int> Vistas{get;set;}
    }
}