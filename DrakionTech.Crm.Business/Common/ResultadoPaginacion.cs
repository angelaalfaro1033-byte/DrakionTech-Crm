namespace DrakionTech.Crm.Business.Common
{
    public class ResultadoPaginacion<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int TamañoPagina { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamañoPagina);
        public bool TienePaginaAnterior => Pagina > 1;
        public bool TienePagianSiguiente => Pagina < TotalPaginas;
    }
}
