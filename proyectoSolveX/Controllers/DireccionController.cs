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
    public class DireccionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DireccionController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ICollection<Direccion> Get()
        {
            return context.Direccion.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var direccion = context.Direccion.FirstOrDefault(x => x.Id == id);
            if(direccion != null)
            {
                return Ok(direccion);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                context.Direccion.Add(direccion);
                context.SaveChanges();
                return Ok(direccion);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Direccion direccion, int id)
        {
            var direccionId = context.Direccion.FirstOrDefault(x => x.Id == id);
            if (direccionId != null)
            {
                context.Entry(direccion).State = EntityState.Modified;
                context.SaveChanges();
                return Ok(direccionId);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var direccion = context.Direccion.FirstOrDefault(x => x.Id == id);
            if(direccion != null)
            {
                context.Direccion.Remove(direccion);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}