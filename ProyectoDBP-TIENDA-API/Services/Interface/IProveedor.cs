using ProyectoDBP_TIENDA_API.Models;

namespace ProyectoDBP_TIENDA_API.Services.Interface
{
    public interface IProveedor
    {
        IEnumerable<TbProveedor> ObtenerProveedores();
        TbProveedor ObtenerProveedorPorId(int id);
        void add(TbProveedor obj);
        void delete(int id);
        void update(TbProveedor obj);
    }
}
