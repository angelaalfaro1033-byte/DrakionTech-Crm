using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IAccountService
{
    Task<(LoginErrorEnum resultado, Usuario? user)> LoginAsync(string email, string password);
    Task<RegistroResultadoEnum> RegistroInicialAsync(string nombre, string apellido, string email, string password, string confirmar);
    Task<(GoogleCallbackResultadoEnum resultado, Usuario? user)> GoogleCallbackAsync(string? email);
}