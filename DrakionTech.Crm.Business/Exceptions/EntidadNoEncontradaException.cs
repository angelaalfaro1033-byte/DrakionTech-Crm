namespace DrakionTech.Crm.Business.Exceptions
{
    public class EntidadNoEncontradaException : DomainException
    {
        public EntidadNoEncontradaException(string entidad, int id)
            : base($"{entidad} con id '{id}' no fue encontrada")
        {
        }
    }
}