using System.ComponentModel.DataAnnotations;
namespace DrakionTech.Crm.Data.Entities.Enums
{
    public enum EtapaOportunidad
    {
        [Display(Name = "Llamada inicial")]
        LlamadaInicial = 1,
        [Display(Name = "Reunión de reconocimiento")]
        ReunionReconocimiento = 2,
        [Display(Name = "Preparación de propuesta")]
        PreparacionPropuesta = 3,
        [Display(Name = "Envío de propuesta")]
        EnvioPropuesta = 4,
        [Display(Name = "Seguimiento de propuesta")]
        SeguimientoPropuesta = 5,
        [Display(Name = "Socialización de propuesta")]
        SocializacionPropuesta = 6,
        [Display(Name = "Ajustes de propuesta")]
        AjustesPropuesta = 7,
        [Display(Name = "Preparación de contrato")]
        PreparacionContrato = 8,
        [Display(Name = "Envío de contrato")]
        EnvioContrato = 9,
        [Display(Name = "Firmado")]
        Firmado = 10
    }
}