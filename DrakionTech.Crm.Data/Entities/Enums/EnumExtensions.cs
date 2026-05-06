using System.ComponentModel;
using System.Reflection;

namespace DrakionTech.Crm.Data.Entities.Enums;

public static class EnumExtensions
{
    public static string? ObtenerDescripcion(this Enum valor)
    {
        return valor
            .GetType()
            .GetField(valor.ToString())
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description;
    }
}