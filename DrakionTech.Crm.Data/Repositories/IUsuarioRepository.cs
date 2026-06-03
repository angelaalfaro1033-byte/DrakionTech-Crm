using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories.Interfaces;

public interface IUsuarioRepository
{
    IQueryable<Usuario> Query();
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario?> GetByEmailAsync(string email);
    Task<Usuario?> GetByIdAsync(int id);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task<Usuario?> GetByTokenAsync(string token);
}