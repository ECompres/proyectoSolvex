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
    public class NominaController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public NominaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ICollection<Nomina> Get()
        {
            return context.Nomina.Include(x => x.Empleados).ToList();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var nomina = context.Nomina.FirstOrDefault(x => x.Id == id);
            if(nomina != null)
            {
                return Ok(nomina);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                context.Nomina.Add(nomina);
                context.SaveChanges();
                return Ok(nomina);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Nomina nomina, int id)
        {
            var NominaId = context.Nomina.FirstOrDefault(x => x.Id == id);
            if (NominaId != null)
            {
                context.Entry(nomina).State = EntityState.Modified;
                context.SaveChanges();
                return Ok(nomina);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var nomina = context.Nomina.FirstOrDefault(x => x.Id == id);
            if(nomina != null)
            {
                context.Nomina.Remove(nomina);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}