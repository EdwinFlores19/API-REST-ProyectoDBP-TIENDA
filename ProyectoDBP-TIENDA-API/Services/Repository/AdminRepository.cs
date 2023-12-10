using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Services.Repository
{
    public class AdminRepository : IAdmin
    {
        private BdInfochill bd = new BdInfochill();


        public void add(TbAdmin obj)
        {
            try
            {
                bd.TbAdmins.Add(obj);//insert into <tabla> values(datos)
                bd.SaveChanges();//actualizar en la BD
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void delete(int id)
        {
            var obj = (from tadmin in bd.TbAdmins
                       where tadmin.IdAdmin == id
                       select tadmin).Single();
            bd.TbAdmins.Remove(obj);//delete from <tabla> where <campo>=id
            bd.SaveChanges();
        }

        public TbAdmin ObtenerAdminPorId(int id)
        {
            var obj = (from tadmin in bd.TbAdmins
                       where tadmin.IdAdmin == id
                       select tadmin).Single();
            return obj;
        }

        public IEnumerable<TbAdmin> ObtenerAdmins()
        {
            return bd.TbAdmins;
        }

        public void update(TbAdmin adminConDatosModificados)
        {
            //var obj = lstProducto.Where(pro=>pro.IdPro == ObjPro.Id).FirstOrDefault();
            var obj = (from tadmin in bd.TbAdmins
                       where tadmin.IdAdmin == adminConDatosModificados.IdAdmin
                       select tadmin).FirstOrDefault();
            if (obj != null)
            {
               
                obj.CodAdmin = adminConDatosModificados.CodAdmin;
                obj.PassAdmin = adminConDatosModificados.PassAdmin;
                

                bd.SaveChanges();
            }
        }
    }
}
