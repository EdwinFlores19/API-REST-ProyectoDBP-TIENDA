using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Services.Repository
{
    public class ProveedorRepository : IProveedor
    {
        private BdInfochill bd = new BdInfochill();


        public void add(TbProveedor obj)
        {
            try
            {
                bd.TbProveedors.Add(obj);//insert into <tabla> values(datos)
                bd.SaveChanges();//actualizar en la BD
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void delete(int id)
        {
            var obj = (from tproveedor in bd.TbProveedors
                       where tproveedor.CodProveedor == id
                       select tproveedor).Single();
            bd.TbProveedors.Remove(obj);//delete from <tabla> where <campo>=id
            bd.SaveChanges();
        }


        public IEnumerable<TbProveedor> ObtenerProveedores()
        {
            return bd.TbProveedors;
        }

        public TbProveedor ObtenerProveedorPorId(int id)
        {
            var obj = (from tproveedor in bd.TbProveedors
                       where tproveedor.CodProveedor == id
                       select tproveedor).Single();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public void update(TbProveedor proveedorConDatosModificados)
        {
            //var obj = lstProducto.Where(pro=>pro.IdPro == ObjPro.Id).FirstOrDefault();
            var obj = (from tproveedor in bd.TbProveedors
                       where tproveedor.CodProveedor == proveedorConDatosModificados.CodProveedor
                       select tproveedor).FirstOrDefault();
            if (obj != null)
            {
                obj.RazSocial = proveedorConDatosModificados.RazSocial;
                obj.RepVenta = proveedorConDatosModificados.RepVenta;
                obj.DirProveedor = proveedorConDatosModificados.DirProveedor;
                obj.TlfProveedor = proveedorConDatosModificados.TlfProveedor;
                bd.SaveChanges();
            }
        }
    }
}
