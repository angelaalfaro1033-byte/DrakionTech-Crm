using System.ComponentModel;

namespace DrakionTech.Crm.Data.Entities.Enums;

public enum EtapaFlujoProyecto
{
    [Description("Firma de contrato")] FirmaContrato,
    [Description("Pago del proyecto")] PagoProyecto,
    [Description("Conformación del equipo")] ConformacionEquipo,
    [Description("Reunión inicial")] ReunionInicial,
    [Description("Información general")] InformacionGeneral,
    [Description("Ejecución del proyecto")] EjecucionProyecto,
    [Description("Seguimiento de fases")] SeguimientoFases,
    [Description("Actas de entrega de fase")] ActasEntregaFase,
    [Description("Reunión de cierre")] ReunionCierre,
    [Description("Acta final")] ActaFinal,
    [Description("Otrosí")] Otrosi,
    [Description("Calificación")] Calificacion,
    [Description("Cierre del proyecto")] CierreProyecto
}