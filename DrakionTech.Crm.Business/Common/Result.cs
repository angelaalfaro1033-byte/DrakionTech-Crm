namespace DrakionTech.Crm.Business.Common
{
    public record Result(bool Success, string? ErrorMessage = null)
    {
        public static Result Ok() => new(true, null);
        public static Result Fail(string message) => new(false, message);
    }
}