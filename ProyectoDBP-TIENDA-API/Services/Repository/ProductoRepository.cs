using Microsoft.Extensions.ObjectPool;
using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Services.Repository
{
    public class ProductoRepository : IProducto
    {
        private BdInfochill bd = new BdInfochill();
        

        public void add(TbProducto obj)
        {
            try
            {
                bd.TbProductos.Add(obj);//insert into <tabla> values(datos)
                bd.SaveChanges();//actualizar en la BD
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void delete(int id)
        {
            var obj = (from tproducto in bd.TbProductos
                       where tproducto.IdPro == id
                       select tproducto).Single();
            bd.TbProductos.Remove(obj);//delete from <tabla> where <campo>=id
            bd.SaveChanges();
        }

        public TbProducto ObtenerProductoPorId(int id)
        {
            var obj = (from tproducto in bd.TbProductos
                       where tproducto.IdPro == id
                       select tproducto).Single();
            return obj;
        }

        public IEnumerable<TbProducto> ObtenerProductos()
        {
            return bd.TbProductos;
        }

        public void update(TbProducto productoConDatosModificados)
        {
        //var obj = lstProducto.Where(pro=>pro.IdPro == ObjPro.Id).FirstOrDefault();
        var obj = (from tproducto in bd.TbProductos
                   where tproducto.IdPro == productoConDatosModificados.IdPro
                   select tproducto).FirstOrDefault();
            if (obj != null)
            {
                obj.IdPro = productoConDatosModificados.IdPro;
                obj.PrePro = productoConDatosModificados.PrePro;
                obj.DesPro = productoConDatosModificados.DesPro;
                obj.CatePro = productoConDatosModificados.CatePro;
                obj.StkAct = productoConDatosModificados.StkAct;

                bd.SaveChanges();
            }
        }
    }
}
