using ProyectoDBP_TIENDA_API.Models;

namespace ProyectoDBP_TIENDA_API.Services.Interface
{
    public interface IProducto
    {
        IEnumerable<TbProducto> ObtenerProductos();
        TbProducto ObtenerProductoPorId(int id);
        void add(TbProducto obj);
        void delete(int id);
        void update(TbProducto obj);
    }
}
