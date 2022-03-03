using ARGDriver.Shared.Models.Insurance;
using ARGDriver.Shared.Models.Settings;
using ARGDriver.Shared.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace ARGDriver.Server.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        // Creación tabla Roles
        public DbSet<Rol> Roles { get; set; }

        //Creacion tabla Usuarios
        public DbSet<User> Users { get; set; }

        //Creacion tabla Aseguradoras
        public DbSet<Insurer> Insurers { get; set; }

        //Creacion tabla Servicios
        public DbSet<Service> Services { get; set; }

        // Creación tabla Evidencias
        public DbSet<Evidences> Evidences { get; set; }

    }
}
