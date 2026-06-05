using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class EmpresaCorreoDto
    {
        public int Id { get; set; }

        [Required, EmailAddress(ErrorMessage = "Correo inválido")]
        public string Correo { get; set; } = null!;

        public bool EsPrincipal { get; set; }
    }
}