using System.ComponentModel.DataAnnotations;

namespace Trekstore.Models
{
    public class CategoriaProveedor
    {
        [Key] public int CategoriaProveedorID { get; set; }

        public string CategoriaProveedorNombre { get; set; } = null!;

        public string CategoriaProveedorDescripcion { get; set; } = null!;

        public virtual ICollection<Providers> Providers { get; set; } = new List<Providers>();
    }
}
