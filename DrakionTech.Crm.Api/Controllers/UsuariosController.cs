using DrakionTech.Crm.Api.DTOs;
using DrakionTech.Crm.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioInfoDto>> GetById(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .Where(u => u.Id == id)
                .Select(u => new UsuarioInfoDto
                {
                    Id = u.Id,
                    NombreCompleto = $"{u.Nombre} {u.Apellido}",
                    Rol = u.Rol.Nombre
                })
                .FirstOrDefaultAsync();

            if (usuario is null)
                return NotFound($"No se encontró el usuario con Id {id}");

            return Ok(usuario);
        }
    }
}