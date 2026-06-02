using Microsoft.AspNetCore.Components;

namespace DrakionTech.Crm.Web.Shared
{
    public abstract class PaginacionBase : ComponentBase
    {
        protected int paginaActual = 1;

        protected int tamañoPagina = 10;

        protected int totalRegistros;

        protected int totalPaginas;

        protected async Task CambiarPaginaAsync(
            int pagina,
            Func<Task> recargar)
        {
            paginaActual = pagina;

            await recargar();
        }
    }
}