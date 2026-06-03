using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Usuario> Query()
    {
        return _context.Usuarios
            .Include(u => u.Rol)
            .AsQueryable();
    }

    public async Task<List<Usuario>> GetAllAsync()
        => await _context.Usuarios.Include(u => u.Rol).ToListAsync();

    public async Task<Usuario?> GetByEmailAsync(string email)
        => await _context.Usuarios.Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Email == email);

    public async Task<Usuario?> GetByIdAsync(int id)
        => await _context.Usuarios.Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task AddAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        var existing = await _context.Usuarios.FindAsync(usuario.Id)
            ?? throw new Exception("Usuario no encontrado");

        existing.Nombre = usuario.Nombre;
        existing.Apellido = usuario.Apellido;
        existing.Email = usuario.Email;
        existing.Telefono = usuario.Telefono;
        existing.RolId = usuario.RolId;
        existing.IsActive = usuario.IsActive;
        existing.FechaModificacion = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task<Usuario?> GetByTokenAsync(string token)
    => await _context.Usuarios
        .FirstOrDefaultAsync(u => u.ActivationToken == token);
}