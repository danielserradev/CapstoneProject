using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RentX.Models;

//[assembly: OwinStartupAttribute(typeof(RentX.Startup))]
[assembly: OwinStartup(typeof(RentX.Startup))]
namespace RentX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
            app.MapSignalR();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Leasor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Leasor";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Renter"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Renter";
                roleManager.Create(role);

            }
        }
    }
}
