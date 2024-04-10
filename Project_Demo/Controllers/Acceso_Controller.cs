using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Diagnostics.CodeAnalysis;

namespace Project_Demo.Controllers

{
    public class Acceso_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DA_Logica _da_usuario = new DA_Logica();

            var usuario = _da_usuario.ValidarUsuario(_usuario.Correo, _usuario.Clave);
            
            if (usuario != null)
            {

                var claims = new List<Claim> { 
                
                    new Claim(ClaimTypes.Name,usuario.Nombre),
                    new Claim("Correo", usuario.Correo)

                }; 

                foreach(string rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var claimsIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIndentity));

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }

          
        }

        public async Task<IActionResult> Salir()
        {
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Acceso_");
        }
    }
}
