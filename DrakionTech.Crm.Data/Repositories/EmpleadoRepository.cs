using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task AgregarAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Empleado empleado)
        {
            var existing = await _context.Empleados.FindAsync(empleado.Id);

            if (existing == null)
                throw new Exception("Empleado no encontrado");

            existing.Nombre = empleado.Nombre;
            existing.Apellido = empleado.Apellido;
            existing.Email = empleado.Email;
            existing.Cargo = empleado.Cargo;
            existing.Rol = empleado.Rol;
            existing.Activo = empleado.Activo;
            existing.FechaModificacion = empleado.FechaModificacion;

            await _context.SaveChangesAsync();
        }
    }
}