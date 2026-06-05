using DrakionTech.Crm.Business.DTOs.SectorEmpresa;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services
{
    public class SectorEmpresaService : ISectorEmpresaService
    {
        private readonly ApplicationDbContext _db;
        public SectorEmpresaService(ApplicationDbContext db) => _db = db;

        public async Task<IEnumerable<SectorEmpresaDto>> ObtenerTodosAsync(CancellationToken ct = default)
            => await _db.SectoresEmpresa
                .OrderBy(s => s.Nombre)
                .Select(s => new SectorEmpresaDto { Id = s.Id, Nombre = s.Nombre })
                .ToListAsync(ct);

        public async Task<SectorEmpresaDto> CrearYObtenerAsync(string nombre, CancellationToken ct = default)
        {
            var existente = await _db.SectoresEmpresa
                .FirstOrDefaultAsync(s => s.Nombre.ToLower() == nombre.ToLower().Trim(), ct);
            if (existente != null)
                return new SectorEmpresaDto { Id = existente.Id, Nombre = existente.Nombre };

            var nuevo = new SectorEmpresa { Nombre = nombre.Trim() };
            _db.SectoresEmpresa.Add(nuevo);
            await _db.SaveChangesAsync(ct);
            return new SectorEmpresaDto { Id = nuevo.Id, Nombre = nuevo.Nombre };
        }

        public async Task<IEnumerable<SubsectorEmpresaDto>> ObtenerSubsectoresPorSectorAsync(
            int sectorId, CancellationToken ct = default)
            => await _db.SubsectoresEmpresa
                .Where(sub => sub.Sectores.Any(s => s.Id == sectorId))
                .OrderBy(sub => sub.Nombre)
                .Select(sub => new SubsectorEmpresaDto
                {
                    Id = sub.Id,
                    Nombre = sub.Nombre,
                    SectorIds = sub.Sectores.Select(s => s.Id).ToList()
                })
                .ToListAsync(ct);

        public async Task<SubsectorEmpresaDto> CrearSubsectorYObtenerAsync(
            string nombre, int sectorId, CancellationToken ct = default)
        {
            var sector = await _db.SectoresEmpresa
                .Include(s => s.Subsectores)
                .FirstOrDefaultAsync(s => s.Id == sectorId, ct)
                ?? throw new InvalidOperationException("Sector no encontrado");

            var existente = await _db.SubsectoresEmpresa
                .Include(sub => sub.Sectores)
                .FirstOrDefaultAsync(sub => sub.Nombre.ToLower() == nombre.ToLower().Trim(), ct);

            if (existente != null)
            {
                if (!existente.Sectores.Any(s => s.Id == sectorId))
                    existente.Sectores.Add(sector);
                await _db.SaveChangesAsync(ct);
                return new SubsectorEmpresaDto
                {
                    Id = existente.Id,
                    Nombre = existente.Nombre,
                    SectorIds = existente.Sectores.Select(s => s.Id).ToList()
                };
            }

            var nuevo = new SubsectorEmpresa { Nombre = nombre.Trim() };
            nuevo.Sectores.Add(sector);
            _db.SubsectoresEmpresa.Add(nuevo);
            await _db.SaveChangesAsync(ct);
            return new SubsectorEmpresaDto
            {
                Id = nuevo.Id,
                Nombre = nuevo.Nombre,
                SectorIds = new List<int> { sectorId }
            };
        }
    }
}