using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories;

public interface IPublicacionMarketingRepository
{
    IQueryable<PublicacionMarketing> Query();

    Task<List<PublicacionMarketing>> ObtenerTodosAsync();

    Task<PublicacionMarketing?> ObtenerPorIdAsync(int id);

    Task AgregarAsync(PublicacionMarketing publicacion);

    Task ActualizarAsync(PublicacionMarketing publicacion);

    Task EliminarAsync(PublicacionMarketing publicacion);
}