using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IAccountService
{
    Task<LoginErrorEnum> LoginAsync(string email, string password);
    Task<RegistroResultadoEnum> RegistroInicialAsync(string nombre, string apellido, string email, string password, string confirmar);
    Task<(GoogleCallbackResultadoEnum resultado, Empleado? user)> GoogleCallbackAsync(string? email);
}