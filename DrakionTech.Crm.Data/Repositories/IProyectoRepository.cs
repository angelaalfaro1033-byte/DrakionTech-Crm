using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories;

public interface IProyectoRepository
{
    IQueryable<Proyecto> Query();
    Task<List<Proyecto>> ObtenerTodosAsync();
    Task<Proyecto?> ObtenerPorIdAsync(int id);
    Task AgregarAsync(Proyecto proyecto);
    Task ActualizarAsync(Proyecto proyecto);
    Task EliminarAsync(Proyecto proyecto);
}