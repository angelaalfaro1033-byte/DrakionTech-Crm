using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
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
            return await _context.Empleados
                .Include(e => e.Salario)
                .ToListAsync();
        }

        public async Task<Empleado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Empleados
                .Include(e => e.Salario)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AgregarAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Empleado empleado)
        {
            var existing = await _context.Empleados
                .Include(e => e.Salario)
                .FirstOrDefaultAsync(e => e.Id == empleado.Id);

            if (existing == null)
                throw new Exception("Empleado no encontrado");

            existing.Nombre = empleado.Nombre;
            existing.Apellido = empleado.Apellido;
            existing.Email = empleado.Email;
            existing.Cargo = empleado.Cargo;
            existing.Rol = empleado.Rol;
            existing.Activo = empleado.Activo;
            existing.FechaModificacion = empleado.FechaModificacion;
            existing.TipoDocumento = empleado.TipoDocumento;
            existing.NumeroDocumento = empleado.NumeroDocumento;
            existing.PasswordHash = empleado.PasswordHash;
            existing.IsActive = empleado.IsActive;
            existing.ActivationToken = empleado.ActivationToken;
            existing.ActivationTokenExpiration = empleado.ActivationTokenExpiration;

            if (empleado.Salario is not null)
            {
                if (existing.Salario is null)
                    existing.Salario = new EmpleadoSalario { Salario = empleado.Salario.Salario };
                else
                {
                    existing.Salario.Salario = empleado.Salario.Salario;
                    existing.Salario.FechaModificacion = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Empleado?> ObtenerPorEmailAsync(string email)
        {
            return await _context.Empleados
                .Include(e => e.Salario)
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Empleado?> ObtenerPorNumeroDocumentoAsync(string numeroDocumento)
        {
            return await _context.Empleados
                .Include(e => e.Salario)
                .FirstOrDefaultAsync(e => e.NumeroDocumento == numeroDocumento);
        }
    }
}