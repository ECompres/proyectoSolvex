using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoSolveX.Model
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public Direccion Direccion { get; set;  }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public double Sueldo { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int TipoUsuario { get; set; }
        [ForeignKey("nomina")]
        public int NominaId { get; set; }
        public Nomina Nomina { get; set; }


    }
}
