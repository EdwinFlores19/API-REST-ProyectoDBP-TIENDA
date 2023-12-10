using ProyectoDBP_TIENDA_API.Models;

namespace ProyectoDBP_TIENDA_API.Services.Interface
{
    public interface IUsuario
    {
        IEnumerable<TbUsuario> ObtenerUsuarios();
        TbUsuario ObtenerUsuarioPorId(string id);
        void add(TbUsuario obj);
        void delete(string id);
        void update(TbUsuario obj);
    }
}
