using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_Usuario.Data;
using api_Usuario.Models;
using Microsoft.AspNetCore.Authorization;

namespace api_Usuario.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuariosContext _context;

        public UsuarioController(UsuariosContext context) 
        { 
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        [HttpGet("{clave}")]
        public async Task<ActionResult<string>> GetUsuarios(string clave)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarios = _context.Usuarios.FirstOrDefault(x => x.ClaveUsuario == clave); 

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios.Region;
        }

        [HttpPost]
        [Route("PostUsuarios")]
        public async Task<ActionResult<Usuario>> PostUsuarios(Usuario usuarios)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'UsuariosContext.Usuarios'  is null.");
            }
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuarios.Id }, usuarios);
        }



    }
}
