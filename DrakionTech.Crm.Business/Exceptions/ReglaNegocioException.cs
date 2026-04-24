namespace DrakionTech.Crm.Business.Exceptions
{
    public class ReglaNegocioException : DomainException
    {
        public ReglaNegocioException(string mensaje)
            : base(mensaje)
        {
        }
    }
}