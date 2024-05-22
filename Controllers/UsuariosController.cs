using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _context.Usuarios.ToList();

            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Login([FromBody] Usuario loginUsuario)
        {
            var usuario = _context.Usuarios.FirstOrDefault( u => u.Nombre == loginUsuario.Nombre && u.Password == loginUsuario.Password);
            if(usuario == null)
                return Unauthorized();

            return Ok(usuario);
        }
    }
}