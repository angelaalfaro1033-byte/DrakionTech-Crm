using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Data.Entities.Enums
{
    public enum EtapaOportunidad
    {
        Lead = 1,
        Prospecto = 2,
        [Display(Name = "Propuesta Enviada")] 
        PropuestaEnviada = 3,
        Negociacion = 4,
        Ganado = 5,
        Perdido = 6
    }
}