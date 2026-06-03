using Microsoft.AspNetCore.Components;

namespace DrakionTech.Crm.Web.Shared
{
    public abstract class PaginacionBase : ComponentBase
    {
        protected int paginaActual = 1;
        protected int totalRegistros;
        protected int totalPaginas;

        protected virtual int TamañoPaginaDefecto => 10;

        private int _tamañoPagina;

        protected int tamañoPagina
        {
            get => _tamañoPagina > 0 ? _tamañoPagina : TamañoPaginaDefecto;
            set => _tamañoPagina = value;
        }

        protected async Task CambiarPaginaAsync(int pagina, Func<Task> recargar)
        {
            paginaActual = pagina;
            await recargar();
        }
    }
}