using ProyectoDBP_TIENDA_API.Models;

namespace ProyectoDBP_TIENDA_API.Services.Interface
{
    public interface IAdmin
    {
        IEnumerable<TbAdmin> ObtenerAdmins();
        TbAdmin ObtenerAdminPorId(int id);
        void add(TbAdmin obj);
        void delete(int id);
        void update(TbAdmin adminConDatosModificados);
    }
}
