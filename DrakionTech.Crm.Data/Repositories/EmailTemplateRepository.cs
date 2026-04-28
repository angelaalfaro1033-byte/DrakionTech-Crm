using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class EmailTemplateRepository : IEmailTemplateRepository
{
    private readonly ApplicationDbContext _context;

    public EmailTemplateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmailTemplate?> GetByNombreAsync(string nombre)
    {
        return await _context.EmailTemplates
            .FirstOrDefaultAsync(x => x.Nombre == nombre && x.Activo);
    }
}