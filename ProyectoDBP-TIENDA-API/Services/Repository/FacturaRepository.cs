using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Services.Repository
{
    public class FacturaRepository : IFactura
    {
        private BdInfochill bd = new BdInfochill();


        public void add(TbFactura obj)
        {
            try
            {
                bd.TbFacturas.Add(obj);//insert into <tabla> values(datos)
                bd.SaveChanges();//actualizar en la BD
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void delete(int id)
        {
            var obj = (from tfactura in bd.TbFacturas
                       where tfactura.IdFac == id
                       select tfactura).Single();
            bd.TbFacturas.Remove(obj);//delete from <tabla> where <campo>=id
            bd.SaveChanges();
        }

        public TbFactura ObtenerFacturaPorId(int id)
        {
            var obj = (from tfactura in bd.TbFacturas
                       where tfactura.IdFac == id
                       select tfactura).Single();
            return obj;
        }

        public IEnumerable<TbFactura> ObtenerFacturas()
        {
            return bd.TbFacturas;
        }

        public void update(TbFactura facturaConDatosModificados)
        {
            //var obj = lstProducto.Where(pro=>pro.IdPro == ObjPro.Id).FirstOrDefault();
            var obj = (from tfactura in bd.TbFacturas
                       where tfactura.IdFac == facturaConDatosModificados.IdFac
                       select tfactura).FirstOrDefault();
            if (obj != null)
            {
                
                obj.FechaReg = facturaConDatosModificados.FechaReg;
                

                bd.SaveChanges();
            }
        }
    }
}
