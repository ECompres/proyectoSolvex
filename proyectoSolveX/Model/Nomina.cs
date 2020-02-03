using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoSolveX.Model
{
    public class Nomina
    {
        [Key]
        public int Id { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public List<Empleado> Empleados { get; set; }

    }
}
