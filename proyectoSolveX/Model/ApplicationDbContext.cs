using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoSolveX.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Nomina> Nomina { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
    }
}
