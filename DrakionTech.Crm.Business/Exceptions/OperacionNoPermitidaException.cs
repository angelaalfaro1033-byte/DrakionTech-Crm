namespace DrakionTech.Crm.Business.Exceptions
{
    public class OperacionNoPermitidaException : DomainException
    {
        public OperacionNoPermitidaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}