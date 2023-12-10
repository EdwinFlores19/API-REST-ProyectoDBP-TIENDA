using ProyectoDBP_TIENDA_API.Models;

namespace ProyectoDBP_TIENDA_API.Services.Interface
{
    public interface IFactura
    {
        IEnumerable<TbFactura> ObtenerFacturas();
        TbFactura ObtenerFacturaPorId(int id);
        void add(TbFactura obj);
        void delete(int id);
        void update(TbFactura facturaConDatosModificados);
    }
}
