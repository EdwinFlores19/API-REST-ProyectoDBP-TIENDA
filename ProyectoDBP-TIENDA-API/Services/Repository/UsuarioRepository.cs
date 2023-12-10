using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Services.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private BdInfochill bd = new BdInfochill();


        public void add(TbUsuario obj)
        {
            try
            {
                bd.TbUsuarios.Add(obj);//insert into <tabla> values(datos)
                bd.SaveChanges();//actualizar en la BD
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void delete(string id)
        {
            var obj = (from tusuario in bd.TbUsuarios
                       where tusuario.IdUsu == id
                       select tusuario).Single();
            bd.TbUsuarios.Remove(obj);//delete from <tabla> where <campo>=id
            bd.SaveChanges();
        }

        public IEnumerable<TbUsuario> ObtenerUsuarios()
        {
            return bd.TbUsuarios;
        }

        public TbUsuario ObtenerUsuarioPorId(string id)
        {
            var obj = (from tusuario in bd.TbUsuarios
                       where tusuario.IdUsu == id
                       select tusuario).Single();
            return obj;
        }

        public void update(TbUsuario usuarioConDatosModificados)
        {
            //var obj = lstProducto.Where(pro=>pro.IdPro == ObjPro.Id).FirstOrDefault();
            var obj = (from tusuario in bd.TbUsuarios
                       where tusuario.IdUsu == usuarioConDatosModificados.IdUsu
                       select tusuario).FirstOrDefault();
            if (obj != null)
            {
                
                obj.NomCli = usuarioConDatosModificados.NomCli;
                obj.ApeCli = usuarioConDatosModificados.ApeCli;
                obj.CorreoCli = usuarioConDatosModificados.CorreoCli;
                obj.DniCli = usuarioConDatosModificados.DniCli;
                obj.TlfCli = usuarioConDatosModificados.TlfCli;
                


                bd.SaveChanges();
            }
        }
    }
}
