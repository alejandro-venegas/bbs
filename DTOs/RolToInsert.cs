using System.Collections.Generic;
namespace bbs.DTOs
{
    public class RolToInsert
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<int> Vistas{get;set;}
    }
}