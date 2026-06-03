using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Common
{
    public static class PaginacionExtensions
    {
        public static async Task<ResultadoPaginacion<T>> PaginarAsync<T>(
            this IQueryable<T> query,
            int pagina,
            int tamañoPagina = 10,
            CancellationToken ct = default)
        {
            if (pagina < 1) pagina = 1;
            if (tamañoPagina < 1) tamañoPagina = 10;

            var total = await query.CountAsync(ct);
            var items = await query
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync(ct);

            return new ResultadoPaginacion<T>
            {
                Items = items,
                TotalRegistros = total,
                Pagina = pagina,
                TamañoPagina = tamañoPagina
            };
        }
    }
}