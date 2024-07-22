using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dvp_server.Context;
using dvp_server.Models;
using NuGet.Protocol;
using Microsoft.OpenApi.Any;

namespace dvp_server.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet("get_personas")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET: api/Personas/5
        [HttpGet("get_persona/{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create_persona")]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            persona.Fecha_creacion = DateTime.Now;
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        [HttpPost("new_user")]
        public async Task<ActionResult<Persona>> PostNewUser(Persona persona, string password)
        {
            Usuario usuario = new()
            {
                Fecha_creacion = DateTime.Now,
                Password = password
            };

            Persona new_persona = new()
            { 
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                Email = persona.Email,
                Fecha_creacion = usuario.Fecha_creacion,
                Tipo_documento = persona.Tipo_documento,
                Numero_documento = persona.Numero_documento,
                Usuario = usuario
            };
            _context.Personas.Add(new_persona);
            _context.SaveChanges();

            return CreatedAtAction("GetPersona", new { id = new_persona.Id }, new_persona);
        }

        [HttpPost("set_password")]
        public async Task<ActionResult<Persona>> PostSetPassWord(LoginInfo info)
        {
            var persona = _context.Personas.Include(p => p.Usuario).Where(
                p => p.Tipo_documento == info.Tipo_documento &&
                p.Numero_documento == info.Numero_documento
            ).FirstOrDefault();

            persona.Usuario = new() { 
                Fecha_creacion = DateTime.Now,
                Password = info.Password
            };
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        [HttpPost("login")]
        public ActionResult<Persona> LogIn(LoginInfo info)
        {
            var persona = _context.Personas.Include(p => p.Usuario).Where(
                p => p.Tipo_documento == info.Tipo_documento &&
                p.Numero_documento == info.Numero_documento &&
                p.Usuario != null &&
                p.Usuario.Password == info.Password
            ).FirstOrDefault();

            return persona;
        }

        [HttpPost("has_password")]
        public async Task<ActionResult<Persona>> HasPassword(LoginInfo info)
        {
            var persona = _context.Personas.Include(p=> p.Usuario).Where(
                p => p.Tipo_documento == info.Tipo_documento &&
                p.Numero_documento == info.Numero_documento
            ).FirstOrDefault();

            return persona;
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
