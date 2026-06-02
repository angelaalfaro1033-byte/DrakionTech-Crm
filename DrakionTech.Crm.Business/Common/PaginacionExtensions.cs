namespace DrakionTech.Crm.Business.Common
{
    public static class PaginacionExtensions
    {
        public static ResultadoPaginacion<T> Paginar<T>(
            this IQueryable<T> query,
            int pagina,
            int tamañoPagina = 10)
        {
            if (pagina < 1) pagina = 1;
            if (tamañoPagina < 1) tamañoPagina = 10;

            var total = query.Count();
            var items = query
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToList();

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
