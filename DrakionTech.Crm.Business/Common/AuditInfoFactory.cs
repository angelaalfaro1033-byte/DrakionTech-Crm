using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Business.Common;

public static class AuditInfoFactory
{
    public static AuditInfoDto FromEntity(AuditableEntity entity)
    {
        return new AuditInfoDto
        {
            CreatedByUserId = entity.CreatedByUserId,
            CreatedByUserName = FormatUserName(entity.CreatedByUser),
            CreatedAt = entity.CreatedAt,
            ModifiedByUserId = entity.ModifiedByUserId,
            ModifiedByUserName = FormatUserName(entity.ModifiedByUser),
            ModifiedAt = entity.ModifiedAt
        };
    }

    public static string? FormatUserName(Usuario? usuario)
    {
        if (usuario is null)
            return null;

        var fullName = $"{usuario.Nombre} {usuario.Apellido}".Trim();
        return string.IsNullOrWhiteSpace(fullName) ? usuario.Email : fullName;
    }
}
