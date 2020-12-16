using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SoporteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SoporteWeb.Clase
{
    public class Utility
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string rol)
        {
            var role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if(!role.RoleExists(rol))
            {
                role.Create(new IdentityRole(rol));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("superuser@gmail.com");

            if(user==null)
            {
                CreateSuperuser("superuser@gmail.com","Admin_123",null,"Administrator");
            }
        }

        private static void CreateSuperuser(string email, string password, string phone, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser()
            {
                UserName = email,
                Email=email,
                PhoneNumber=phone
            };
            //crea el usuario.
            userManager.Create(user,password);
            //crea un rol.
            userManager.AddToRole(user.Id, rol);
        }
        //Destructor para cerrar la base de datos.
        public void Dispose()
        {
            db.Dispose();
        }
    }
}