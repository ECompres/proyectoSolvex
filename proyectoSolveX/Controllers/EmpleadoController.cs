using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoSolveX.Model;

namespace proyectoSolveX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmpleadoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ICollection<Empleado> Get()
        {
            return context.Empleados.Include(x=>x.Direccion).ToList();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var empleado = context.Empleados.FirstOrDefault(x => x.Id == id);
            if(empleado != null)
            {
                return Ok(empleado);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return Ok(empleado);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Empleado empleado, int id)
        {
            var empleadoId = context.Empleados.FirstOrDefault(x => x.Id == id);
            if(empleadoId != null)
            {
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
                return Ok(empleado);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var empleado = context.Empleados.FirstOrDefault(x => x.Id == id);
            if(empleado != null)
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}