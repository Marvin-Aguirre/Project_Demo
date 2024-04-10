using Project_Demo.Models;
namespace Project_Demo.Data
{
    public class DA_Logica
    {

        public List<Usuario> ListaUsuario()
        {
            return new List<Usuario>
            {
                new Usuario{Nombre="Jose", Correo="administrador@gmail.com", Clave="12345", Roles=new string[] {"Administrador"}},
                new Usuario{Nombre="Marvin", Correo="supervisor@gmail.com", Clave="12345", Roles=new string[] {"Supervisor"}},
                new Usuario{Nombre="Juan", Correo="cliente@gmail.com", Clave="12345", Roles=new string[] {"Cliente"}}
            };
        }

        public Usuario ValidarUsuario(string _correo, string clave)
        {
            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == clave).FirstOrDefault();
        } 

    }
}
